using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using ExamApp.BLL.Abstract;
using ExamApp.Entities;
using ExamApp.WebUICore.ViewModels;
using HtmlAgilityPack;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ExamApp.WebUICore.Controllers
{

    public class ExamController : Controller
    {

        private IExamService _examService;
        private IQuestionService _questionService;
        private IOptionsService _optionsService;

        public ExamController(IExamService examService, IQuestionService questionService, IOptionsService optionsService)
        {
            _examService = examService;
            _questionService = questionService;
            _optionsService = optionsService;

        }
        public static List<String> contents;

        public static List<string> titles;
        public IActionResult Index()
        {
            return View();
        }
        public ActionResult ExamCreate()
        {

            int counter = 0;
            titles = new List<string>();
            contents = new List<string>();

            ServicePointManager.SecurityProtocol = (SecurityProtocolType)3072;
            string link = "http://wired.com/most-recent/";
            Uri url = new Uri(link);
            WebClient client = new WebClient();
            client.Encoding = Encoding.UTF8;
            string html = client.DownloadString(url);
            HtmlAgilityPack.HtmlDocument document = new HtmlAgilityPack.HtmlDocument();
            document.LoadHtml(html);

            var XPath = @"//*[@id=""app-root""]/div/div[3]/div/div[2]/div/div[1]/div/div/ul";

            var nodes = document.DocumentNode.SelectNodes(XPath);

            contents.Clear();
            foreach (var items in nodes)
            {
                foreach (var innerItem in items.SelectNodes("li"))
                {
                    try
                    {
                        contents.Add(get(innerItem.SelectNodes("a")[0].Attributes["href"].Value));
                        counter++;
                    }
                    catch (Exception)
                    {
                        continue;
                    }

                    titles.Add(innerItem.SelectNodes("div//a//h2")[0].InnerHtml);
                    if (counter >= 5)
                        break;
                }
            }

            ViewBag.Contents = contents;
            ViewBag.Titles = titles;

            return View();
        }

        [HttpPost]
        public IActionResult GetContent(int id)
        {

            int gelen = id;
            var veri = contents[id - 1].ToString();

            return Json(veri);
        }
        public string get(string gelenLink)
        {
            string link = "http://wired.com" + gelenLink;
            Uri url = new Uri(link);
            WebClient client = new WebClient();
            client.Encoding = Encoding.UTF8;
            string html = client.DownloadString(url);
            HtmlAgilityPack.HtmlDocument document = new HtmlAgilityPack.HtmlDocument();
            document.LoadHtml(html);


            StringBuilder metin = new StringBuilder();
            HtmlNodeCollection secilenHtmlList = document.DocumentNode.SelectNodes("/html/body/div[1]/div/main/article/div[2]/div/div[1]/div[1]/div[1]");
            foreach (var items in secilenHtmlList)
            {
                foreach (var innerItem in items.SelectNodes("p"))
                {

                    metin.Append(innerItem.InnerHtml);

                }
            }
            return metin.ToString();

        }

        public IActionResult CreateExam()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateExam(ExamCreateModel model)
        {

            Exam exam = new Exam();
            int d = Convert.ToInt32(model.Title);
            exam.ExamContent = model.Content;
            exam.ExamTitle = titles[d - 1].ToString();
            exam.CreatedDate = DateTime.Now;
            _examService.Add(exam);
            int exam_id = exam.ExamId;

            for (int i = 0; i < 4; i++)
            {
                Question question = new Question();
                question.ExamId = exam_id;
                question.QuestionContent = model.Questions[i].QuestionContent;
                _questionService.Add(question);
                question.ExamId = exam_id;
                int question_id = question.QuestionId;

                for (int j = 0; j < 4; j++)
                {
                    Option option = new Option();
                    option.selection = model.Questions[i].Options[j].selection;

                    option.QuestionId = question_id;

                    string a = model.Questions[i].Answer.ToString().ToLower();


                    if (((model.Questions[i].Answer) - 65) == j)
                        option.IsCorrect = "true";

                    else
                        option.IsCorrect = "false";

                    _optionsService.Add(option);
                }
            }

            return View("Index");
        }

        public IActionResult ExamList()
        {
            List<Exam> exams = new List<Exam>();
            exams = _examService.GetAll();
            return View(exams);
        }

        public IActionResult ExamDelete(int id)
        {
            if (id != 0)
            {
                Exam deletedExam = _examService.GetById(id);
                _examService.Delete(deletedExam);

                List<Question> questions = new List<Question>();
                questions = _questionService.GetAll().Where(x => x.ExamId == id).ToList();

                foreach (var q in questions)
                {
                    _questionService.Delete(q);

                    List<Option> options = new List<Option>();
                    options = _optionsService.GetAll().Where(x => x.QuestionId == q.QuestionId).ToList();

                    foreach (var o in options)
                    {
                        _optionsService.Delete(o);
                    }
                }
            }
            return RedirectToAction("ExamList");

        }
        public IActionResult ExamGo(int id)
        {
            Exam exam = _examService.GetById(id);
            GoExamModel goExamModel = new GoExamModel();
            goExamModel.Questions = _questionService.GetAll().Where(x => x.ExamId == exam.ExamId).ToList()
                             .Select(y => new Question
                             {
                                 QuestionContent = y.QuestionContent,
                                 Options = _optionsService.GetAll().Where(z => z.QuestionId == y.QuestionId).ToList()
                             }).ToList();

            goExamModel.Exam = exam;
            return View(goExamModel);
        }
    }


}


