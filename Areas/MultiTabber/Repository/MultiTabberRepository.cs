using AppService.Areas.MultiTabber.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AppService.Areas.MultiTabber.Repository
{
    public class MultiTabberRepository:IMultiTabberRepository
    {
        public MultiTabberRepository()
        {

        }

        public IEnumerable<EData> getErrData(string _from, string to)
        {
            List<EData> data = new List<EData>();
            List<string> daysList = getDates(_from, to);

            try
            {
                MultiTabberDataContext ctx = new MultiTabberDataContext();
                int num = 1;

                foreach(string d in daysList)
                {
                    var exist = ctx.ErrTabber.Where(m => m.err == d);

                    foreach(var er in exist)
                    {
                        data.Add(new EData
                        {
                            date = er.date,
                            descrip = er.description,
                            err = er.err,
                            Id = num++
                        });
                    }
                }
            }
            catch(Exception)
            {

            }

            return data;
        }

        public IEnumerable<MData> getUserData(string _from, string to, int activityCount)
        {
            List<MData> data = new List<MData>();
            List<string> daysList = getDates(_from, to);

            try
            {
                if (activityCount > 0)
                {
                    MultiTabberDataContext ctx = new MultiTabberDataContext();

                    int num = 1;
                    foreach (string d in daysList)
                    {
                        var exist = ctx.Tabber.Where(n => n.lastused == d && n.ActiveCount >= activityCount);

                        foreach (UserTable m in exist)
                            data.Add(new MData
                            {
                                Id = num++,
                                email = m.email,
                                lastused = m.lastused,
                                ActivityCount = m.ActiveCount
                            });
                    }
                }
                else
                {

                    MultiTabberDataContext ctx = new MultiTabberDataContext();                  

                    int num = 1;
                    foreach (string d in daysList)
                    {
                        var exist = ctx.Tabber.Where(n => n.lastused == d);

                        foreach(UserTable m in exist)
                            data.Add(new MData
                            {
                                Id = num++,
                                email = m.email,
                                lastused = m.lastused,
                                ActivityCount = m.ActiveCount
                            });
                    }
                }
            }
            catch (Exception ex)
            {

            }
            return data;
        }

        List<string> getDates(string _from,string to)
        {
            List<string> daysList = new List<string>();
            try
            {
                TimeSpan days = DateTime.Parse(to) - DateTime.Parse(_from);
                
                daysList.Add(_from);
                string date = string.Format("{0:M/d/yyyy}", _from);

                for (int i = 0; i < days.Days; i++)
                {
                    date = string.Format("{0:M/d/yyyy}", DateTime.Parse(date).AddDays(1).ToShortDateString());
                    daysList.Add(date);
                }
            }
            catch(Exception ex)
            {

            }

            return daysList;
        }
    }
}