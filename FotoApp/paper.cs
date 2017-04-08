using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FotoApp
{
    public class paper
    {
        public int id;
        public  string Type;
        public List<Sises> listSises;

        
    }

    public  class Sises
    {
        public int id;
        public string sises;
    }

    public class InitPapers
    {
        private List<paper> peperList = new List<paper>
        {
            new paper()
            {
                id = 1,
                Type = "papers1",
                listSises = new List<Sises>
                {
                    new Sises()
                    {
                        id = 1,
                        sises = "sizes1",
                    },
                    
                    new Sises()
                    {
                        id = 3,
                        sises = "sizes3",
                    },
                    new Sises()
                    {
                        id = 5,
                        sises = "5",
                    },

                    new Sises()
                    {
                        id = 3,
                        sises = "sizes3",
                    }


                }
            },
            new paper()
            {
                id = 2,
                Type = "papers 2",
                listSises = new List<Sises>
                {
                    new Sises()
                    {
                        id = 1,
                        sises = "sizes1",
                    },

                    new Sises()
                    {
                        id = 3,
                        sises = "sizes3",
                    },
                    new Sises()
                    {
                        id = 2,
                        sises = "sizes2",
                    },

                    new Sises()
                    {
                        id = 3,
                        sises = "sizes3",
                    }


                }
            }
        };
    }
}
