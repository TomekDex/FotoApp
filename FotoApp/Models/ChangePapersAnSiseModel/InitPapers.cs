using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Caliburn.Micro;

namespace FotoApp.Models.ChangePapersAnSiseModel
{
    public class InitPapers
    {
        public BindableCollection<Types> peperList { get; }


        public InitPapers()
        {
            peperList = new BindableCollection<Types>
            {
                new Types()
                {
                    id = 1,
                    Type = "papers1",
                    listSises = new BindableCollection<Sizes>()
                    {
                        new Sizes()
                        {
                            id = 1,
                            Sises = "sizes1",
                        },

                        new Sizes()
                        {
                            id = 3,
                            Sises = "sizes3",
                        },
                        new Sizes()
                        {
                            id = 5,
                            Sises = "5",
                        },

                        new Sizes()
                        {
                            id = 3,
                            Sises = "sizes3",
                        }
                    }
                },
                new Types()
                {
                    id = 2,
                    Type = "papers 2",
                    listSises = new BindableCollection<Sizes>()
                    {
                        new Sizes()
                        {
                            id = 1,
                            Sises = "sizes1",
                        },

                        new Sizes()
                        {
                            id = 3,
                            Sises = "sizes3",
                        },
                        new Sizes()
                        {
                            id = 2,
                            Sises = "sizes2",
                        },

                        new Sizes()
                        {
                            id = 3,
                            Sises = "sizes3",
                        }


                    }
                }
            };

        }
    }
}
