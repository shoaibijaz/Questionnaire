using HealthQues.Domain;
using HealthQues.DTOs;

namespace HealthQues.Data
{
    public class QuestionSeeds
    {
        public static void SeedData(ApplicationDbContext context)
        {
            var k1 = q1();
            var k2 = q2();
            var k3 = q3();
            var k4 = q4();
            var k4_1 = q4_1();
            var k4_2 = q4_2();
            var k4_3 = q4_3();
            var k4_4 = q4_4();
            var k4_4_1 = q4_4_1();

            k4_1.Parent = k4_1;
            k4_2.Parent = k4_1;
            k4_3.Parent = k4_1;
            k4_4.Parent = k4_1;

            k4_4_1.Parent = k4_4;

            var ls = new List<QuestionDto>();
            ls.Add(k1);
            ls.Add(k2);
            ls.Add(k3);
            ls.Add(k4);
            ls.Add(k4_1);
            ls.Add(k4_2);
            ls.Add(k4_3);
            ls.Add(k4_4);
            ls.Add(k4_4_1);

            foreach (var item in ls)
            {
                var q = new Question();
                q.Title = item.Title;
                q.SelectionType = item.SelectionType;
                q.Domain = item.Domain;
                q.QuestionnaireId = 12;

                context.Questions.Add(q);

                foreach (var ans in item.Answers)
                {
                    var answer = new QuestionAnswer()
                    {
                        Question = q,
                        ScorePoint = ans.ScorePoint,
                        Title = ans.Title
                    };

                    context.QuestionAnswers.Add(answer);
                   
                }

                context.SaveChanges();
            }
        }

       static QuestionDto q1()
        {
            QuestionDto question = new();

            question.Title = "How would you rate your overall health? ";
            question.Domain = "Medical";
            question.SelectionType = "radio";
            question.Answers.Add(new DTOs.AnswerDto()
            {
                Title = "Poor",
                ScorePoint = 1,
            });
            question.Answers.Add(new DTOs.AnswerDto()
            {
                Title = "Fair",
                ScorePoint = 0.66,
            });
            question.Answers.Add(new DTOs.AnswerDto()
            {
                Title = "Good",
                ScorePoint = 0.3,
            });
            question.Answers.Add(new DTOs.AnswerDto()
            {
                Title = "Excellent",
                ScorePoint = 0,
            });

            return question;

        }

        static QuestionDto q2()
        {
            DTOs.QuestionDto question = new();

            question.Title = "Please check off the medical problems you have: (Please select all that apply)  ";
            question.Domain = "Medical";
            question.SelectionType = "radio";
            question.Answers.Add(new DTOs.AnswerDto()
            {
                Title = "High Blood Pressure",
                ScorePoint = 1,
            });
            question.Answers.Add(new DTOs.AnswerDto()
            {
                Title = "Congestive Heart Failure",
                ScorePoint = 1,
            });
            question.Answers.Add(new DTOs.AnswerDto()
            {
                Title = "Heart Attack",
                ScorePoint = 1,
            });
            question.Answers.Add(new DTOs.AnswerDto()
            {
                Title = "Hearth Rhythm Problem (Atrial Fibrillation)",
                ScorePoint = 1,
            });
            question.Answers.Add(new DTOs.AnswerDto()
            {
                Title = "Stroke or effects of stroke ",
                ScorePoint = 1,
            });
            question.Answers.Add(new DTOs.AnswerDto()
            {
                Title = "Parkinson’s disease ",
                ScorePoint = 1,
            });

            question.Answers.Add(new DTOs.AnswerDto()
            {
                Title = "Diabetes",
                ScorePoint = 1,
            });

            question.Answers.Add(new DTOs.AnswerDto()
            {
                Title = "Lung problem or breathing problem ",
                ScorePoint = 1,
            });
            return question;
        }

        static QuestionDto q3()
        {
            DTOs.QuestionDto question = new();

            question.Title = "How many medications do you take per day? (Include creams, over the counter medication, herbal products, inhalers, etc.)";
            question.Domain = "Medical";
            question.SelectionType = "radio";
            question.Answers.Add(new DTOs.AnswerDto()
            {
                Title = "10 or more medications",
                ScorePoint = 1,
            });
            question.Answers.Add(new DTOs.AnswerDto()
            {
                Title = "5 to 9 medications",
                ScorePoint = 0.5,
            });
            question.Answers.Add(new DTOs.AnswerDto()
            {
                Title = "0 to 4 medications",
                ScorePoint = 0,
            });
            return question;

        }

        static QuestionDto q4()
        {
            DTOs.QuestionDto question = new();

            question.Title = "Do you experience chronic pain, meaning that the pain has lasted for over 3 months or continued beyond the expected time for healing?";
            question.Domain = "Medical";
            question.SelectionType = "radio";
            question.Answers.Add(new DTOs.AnswerDto()
            {
                Title = "Yes",
                ScorePoint = 0.5,
            });
            question.Answers.Add(new DTOs.AnswerDto()
            {
                Title = "No",
                ScorePoint = 0,
            });
            return question;
        }

        static QuestionDto q4_1()
        {
            DTOs.QuestionDto question = new();

            question.Title = "Do you have this pain on a daily basis?";
            question.Domain = "Medical";
            question.SelectionType = "radio";
            question.Answers.Add(new DTOs.AnswerDto()
            {
                Title = "Yes",
                ScorePoint = 0.5,
            });
            question.Answers.Add(new DTOs.AnswerDto()
            {
                Title = "No",
                ScorePoint = 0,
            });

            return question;
        }

        static QuestionDto q4_2()
        {
            DTOs.QuestionDto question = new();

            question.Title = "Does your pain interfere with your sleep?";
            question.Domain = "Medical";
            question.SelectionType = "radio";
            question.Answers.Add(new DTOs.AnswerDto()
            {
                Title = "Yes",
                ScorePoint = 0.5,
            });
            question.Answers.Add(new DTOs.AnswerDto()
            {
                Title = "No",
                ScorePoint = 0,
            });

            return question;
        }

        static QuestionDto q4_3()
        {
            DTOs.QuestionDto question = new();

            question.Title = "Does your pain impact your ability to do day-to-day activities? (Such as looking after yourself, your home or engaging in social activities)";
            question.Domain = "Medical";
            question.SelectionType = "radio";
            question.Answers.Add(new DTOs.AnswerDto()
            {
                Title = "Yes",
                ScorePoint = 0.5,
            });
            question.Answers.Add(new DTOs.AnswerDto()
            {
                Title = "No",
                ScorePoint = 0,
            });

            return question;
        }

        static QuestionDto q4_4()
        {
            DTOs.QuestionDto question = new();

            question.Title = "How often are you taking pain medications?";
            question.Domain = "Medical";
            question.SelectionType = "radio";
            question.Answers.Add(new DTOs.AnswerDto()
            {
                Title = "Not at all",
                ScorePoint = 0,
            });

            question.Answers.Add(new DTOs.AnswerDto()
            {
                Title = "1-2 times per week",
                ScorePoint = 23
            });

            question.Answers.Add(new DTOs.AnswerDto()
            {
                Title = "3-5 times per week",
                ScorePoint = 23,
            });

            question.Answers.Add(new DTOs.AnswerDto()
            {
                Title = "everyday",
                ScorePoint = 23
            });


            return question;
        }

        static QuestionDto q4_4_1()
        {
            DTOs.QuestionDto question = new();

            question.Title = "Does the pain medication you take control your pain? ";
            question.Domain = "Medical";
            question.SelectionType = "radio";
            question.Answers.Add(new DTOs.AnswerDto()
            {
                Title = "Yes",
                ScorePoint = 0,
            });
            question.Answers.Add(new DTOs.AnswerDto()
            {
                Title = "No",
                ScorePoint = 0.5,
            });

            return question;
        }
    }
}
