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
                    listSises = new BindableCollection<SizeM>()
                    {
                        new SizeM()
                        {
                            id = 1,
                            SizeText = "jdsgkdjf",
                        },

                        new SizeM()
                        {
                            id = 3,
                            SizeText = "sizes3",
                        },
                        new SizeM()
                        {
                            id = 5,
                            SizeText = "5",
                        },

                        new SizeM()
                        {
                            id = 3,
                            SizeText = "sizes3",
                        }
                    }
                },
                new Types()
                {
                    id = 2,
                    Type = "papers 2",
                    listSises = new BindableCollection<SizeM>()
                    {
                        new SizeM()
                        {
                            id = 1,
                            SizeText = "sizes1",
                        },

                        new SizeM()
                        {
                            id = 3,
                            SizeText = "sizes3",
                        },
                        new SizeM()
                        {
                            id = 2,
                            SizeText = "sizes2",
                        },

                        new SizeM()
                        {
                            id = 3,
                            SizeText = "sizes3",
                        }


                    }
                }
            };

        }
    }
}
