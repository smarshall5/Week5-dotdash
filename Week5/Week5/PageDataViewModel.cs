using System;
using System.Collections.Generic;
using System.Text;

namespace Week5
{
    class PageDataViewModel
    {
        public PageDataViewModel(Type type, string title, string description)
        {
            Type = type;
            Title = title;
            Description = description;
        }

        public Type Type { private set; get; }

        public string Title { private set; get; }

        public string Description { private set; get; }

        static PageDataViewModel()
        {
            All = new List<PageDataViewModel>
            {
                new PageDataViewModel(typeof(MorsePage), "Morse Code",
                                      "Morse Code"),
                new PageDataViewModel(typeof(FunPage), "Fun",
                                      "This Does Nothing"),
                new PageDataViewModel(typeof(PersonalityQuizPage), "Personality Quiz Ed Edd Eddy",
                                      "This is for a quiz on ed edd eddy character")
            };
        }

        public static IList<PageDataViewModel> All { private set; get; }
    }
}