namespace Spectare.Classes.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.IO;
    using System.Linq;
    using System.Collections.Generic;
    using System.Reflection;
    using Excel = Microsoft.Office.Interop.Excel;

    internal sealed class Configuration : DbMigrationsConfiguration<Context>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Context context)
        {
            Excel.Application ObjWorkExcel = new Excel.Application();
            //string path = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), @"Spectare.xlsx");

            Excel.Workbook ObjWorkBook = ObjWorkExcel.Workbooks.Open("D:/Ñ#/Spectare.UI/Spectare.Classes/Data/Spectare.xlsx", Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing);
            Excel.Worksheet ObjWorkSheet1 = (Excel.Worksheet)ObjWorkBook.Sheets[1];
            var lastCell1 = ObjWorkSheet1.Cells.SpecialCells(Excel.XlCellType.xlCellTypeLastCell);
            int lastRow1 = (int)lastCell1.Row;
            string[,] list1 = new string[lastCell1.Column, lastCell1.Row];
            for (int i = 0; i < (int)lastCell1.Column; i++) 
                for (int j = 0; j < (int)lastCell1.Row; j++)
                    list1[i, j] = ObjWorkSheet1.Cells[j + 1, i + 1].Text.ToString();

            Excel.Worksheet ObjWorkSheet2 = (Excel.Worksheet)ObjWorkBook.Sheets[2];
            var lastCell2 = ObjWorkSheet2.Cells.SpecialCells(Excel.XlCellType.xlCellTypeLastCell);
            int lastRow2 = (int)lastCell2.Row;
            int lastColumn2 = (int)lastCell2.Column;
            string[,] list2 = new string[lastCell2.Column, lastCell2.Row];
            for (int i = 0; i < (int)lastCell2.Column; i++)
                for (int j = 0; j < (int)lastCell2.Row; j++)
                    list2[i, j] = ObjWorkSheet2.Cells[j + 1, i + 1].Text.ToString();

            Excel.Worksheet ObjWorkSheet3 = (Excel.Worksheet)ObjWorkBook.Sheets[3];
            var lastCell3 = ObjWorkSheet3.Cells.SpecialCells(Excel.XlCellType.xlCellTypeLastCell);
            int lastColumn3 = (int)lastCell3.Column;
            int lastRow3 = (int)lastCell3.Row;
            string[,] list3 = new string[lastCell3.Column, lastCell3.Row];
            for (int i = 0; i < (int)lastCell3.Column; i++)
                for (int j = 0; j < (int)lastCell3.Row; j++)
                    list3[i, j] = ObjWorkSheet3.Cells[j + 1, i + 1].Text.ToString();

            Excel.Worksheet ObjWorkSheet4 = (Excel.Worksheet)ObjWorkBook.Sheets[4];
            var lastCell4 = ObjWorkSheet4.Cells.SpecialCells(Excel.XlCellType.xlCellTypeLastCell);
            int lastColumn4 = (int)lastCell4.Column;
            int lastRow4 = (int)lastCell4.Row;
            string[,] list4 = new string[lastCell4.Column, lastCell4.Row];
            for (int i = 0; i < (int)lastCell4.Column; i++) 
                for (int j = 0; j < (int)lastCell4.Row; j++)
                    list4[i, j] = ObjWorkSheet4.Cells[j + 1, i + 1].Text.ToString();

            ObjWorkBook.Close(false, Type.Missing, Type.Missing);
            ObjWorkExcel.Quit();
            GC.Collect();
            for (int i = 0; i < lastRow1; i++)
            {
                User user = new User
                {
                    Name = list1[0, i],
                    Email = list1[1, i],
                    Password = list1[2, i]
                };
                context.Users.AddOrUpdate(user);
            }

            List<Film> films = new List<Film>();
            List<Actor> actors = new List<Actor>();
            List<FilmType> types = new List<FilmType>();

            for (int j = 0; j < lastRow2; j++)
            {
                Film film = new Film
                {
                    Title = list2[0, j],
                    Description = list2[1, j],
                    PosterLink = list2[2, j],
                    TrailerLink = list2[3, j],
                    WebLink = list2[4, j],
                    PhotoLink1 = list2[5, j],
                    PhotoLink2 = list2[6, j],
                    PhotoLink3 = list2[7, j],
                    Actors = new List<Actor>(),
                    Types = new List<FilmType>(),

                };
                films.Add(film);
            }

            for (int j = 0; j < lastRow3; j++)
            {
                Actor actor = new Actor
                {
                    Name = list3[0, j],
                    Films = new List<Film>()
                };
                string FilmName;
                for (int i = 0; i < lastColumn3 - 1; i++)
                {
                    FilmName = list3[i + 1, j];
                    if (FilmName != "")
                    {
                        int k = 0;
                        while (k < films.Count && FilmName != films[k].Title)
                            k++;
                        if (k < films.Count)
                        {
                            actor.Films.Add(films[k]);
                            films[k].Actors.Add(actor);
                        }
                    }
                }
                actors.Add(actor);
            }

            for (int j = 0; j < lastRow4; j++)
            {
                FilmType type = new FilmType
                {
                    Name = list4[0, j],
                    Films = new List<Film>()
                };
                string FilmName;
                for (int i = 0; i < lastColumn4 - 1; i++)
                {
                    FilmName = list4[i + 1, j];
                    if (FilmName != "")
                    {
                        int k = 0;
                        while (k < films.Count && FilmName != films[k].Title)
                            k++;
                        if (k < films.Count)
                        {
                            type.Films.Add(films[k]);
                            films[k].Types.Add(type);
                        }
                    }
                }
                types.Add(type);
            }
            for (int i = 0; i < films.Count; i++)
                context.Films.AddOrUpdate(d => d.Title, films[i]);
            for (int i = 0; i < actors.Count; i++)
                context.Actors.AddOrUpdate(d => d.Name, actors[i]);
            for (int i = 0; i < types.Count; i++)
                context.Types.AddOrUpdate(d => d.Name, types[i]);

            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
        }
    }
}
