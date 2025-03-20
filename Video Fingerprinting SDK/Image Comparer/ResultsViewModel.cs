using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ImageComparer
{
    public class ResultsViewModel
    {
        public string FirstFile { get; set; }

        public string SecondFile { get; set; }

        public string SimilarityLevel { get; set; }

        //public double SimilarityLevelValue { get; set; }

        //public ResultsViewModel(string firstFile, string secondFile, double similarity)
        //{
        //    FirstFile = firstFile;
        //    SecondFile = secondFile;
        //    //SimilarityLevelValue = similarity;
        //    SimilarityLevel = similarity.ToString("F3");
        //}

        //public ResultsViewModel()
        //{
        //}
    }
}
