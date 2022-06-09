using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam
{
    [Serializable]
    class Auto
    {
        public struct Autos
        {
            public string model;
            public string typeOfAuto;
            public string numOfAuto;
            public int operationTime;
            public string color;
            public int vantag;

            public Autos(string modelOfCar, string typeOfCar, string numOfCar, int TimeOfOper, string colorOfCar, int kgOfCar)
            {
                model = modelOfCar;
                typeOfAuto = typeOfCar;
                numOfAuto = numOfCar;
                operationTime = TimeOfOper;
                color = colorOfCar;
                vantag = kgOfCar;
            }

            public override string ToString()
            {
                string info =
                    $"Model:{this.model}, Type:{this.typeOfAuto}, Car num:{this.numOfAuto}, Operation time:{this.operationTime}, Color:{this.color}, Weight:{this.vantag} kg";
                return  info;
            }
        }
    }
}
