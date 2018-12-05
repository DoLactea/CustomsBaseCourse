using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CustomsBase.Models;
namespace CustomsBase.Data
{
    public class DbInitialize
    {
        public static void Initialize(CustomsContext db)
        {
            db.Database.EnsureCreated();
            if(db.Duties.Any())
            {
                return;
            }

            int customs_agent_number = 100;
            int customs_werehouse_number = 100;
            int type_of_good_number = 100;
            int duti_number = 100;
            string voc = "QWERTYUIOPASDFGHJKLZXCVBNMqwertyuiopasdfghjklzxcvbnm";
            Random random = new Random(1);

            for(int Customs_agentID = 1; Customs_agentID<customs_agent_number; Customs_agentID++)
            {
                string FirstName = GetRandom(voc, 5);
                string SecondName = GetRandom(voc, 8);
                string Serves = GetRandom(voc, 10);
                db.Customs_agents.Add(new Customs_agents {
                    FirstName = FirstName,
                    SecondName = SecondName,
                    Serves = Serves
                });
            }
            db.SaveChanges();


            for(int Types_of_goodsID = 1; Types_of_goodsID < type_of_good_number; Types_of_goodsID++)
            {
                string Name = GetRandom(voc, 5);
                string Unit = GetRandom(voc, 5);
                int Amount_of_duty = random.Next(1, type_of_good_number - 1);
                db.Types_of_goods.Add(new Type_of_Good
                {
                    Name = Name,
                    Unit = Unit,
                    Amount_of_duty = Amount_of_duty
                });
            }
            db.SaveChanges();

            for (int WerehouseID = 1; WerehouseID < customs_werehouse_number; WerehouseID++)
            {
                int Types_of_goodsID = random.Next(1, type_of_good_number - 1);
                db.Customs_werehouses.Add(new Customs_werehouses
                {
                    Types_of_goodsID = Types_of_goodsID
                });
            }
            db.SaveChanges();

            for (int DutiesID = 1; DutiesID < duti_number; DutiesID++)
            {
                int Customs_agentID = random.Next(1, customs_agent_number - 1);
                int WerehouseID = random.Next(1, customs_werehouse_number - 1);
                DateTime Date_receipt = new DateTime(random.Next(1, 30), random.Next(1, 12), random.Next(2000, 2018));
                DateTime Date_of_payment = new DateTime(random.Next(1, 30), random.Next(1, 12), random.Next(2000, 2018));
                DateTime Date_of_goods_call = new DateTime(random.Next(1, 30), random.Next(1, 12), random.Next(2000, 2018));
                db.Duties.Add(new Duti
                {
                    Customs_agentID = Customs_agentID,
                    WerehouseID = WerehouseID,
                    Date_receipt = Date_receipt,
                    Date_of_payment = Date_of_payment,
                    Date_of_goods_call = Date_of_goods_call
                });
            }
            db.SaveChanges();

        }

        public static string GetRandom(string Word, int Length)
        {
            Random random = new Random();
            StringBuilder stringBuilder = new StringBuilder(Length - 1);
            int Position = 0;
            string ret = "";
            for (int i=0; i<Length;i++)
            {
                Position = random.Next(0, Word.Length - 1);
                ret += Word[Position];
            }
            return ret;

        }
    }
}
