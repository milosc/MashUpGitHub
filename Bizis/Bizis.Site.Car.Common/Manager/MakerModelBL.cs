using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Bizis.Common.DL.MsSql;
using Bizis.Site.Car.Common.Properties;
using Bizis.Site.Car.Common.Model;
using System.Data;

namespace Bizis.Site.Car.Common.Manager
{
    public class MakerModelBL
    {

       


        internal static Dictionary<int, string> GetCarMakers()
        {
            Dictionary<int, string> result;
            using (DbTransaction t = new DbTransaction(Settings.Default.SiteCarConnectionString, System.Data.IsolationLevel.ReadUncommitted))
            {
                t.Begin();
                result = new MakerModelDL(t).GetCarMakers();
                t.Commit();
            }
            return result;
        }

        internal static Dictionary<int, string> GetCarModels(int makerId)
        {
            Dictionary<int, string> result;
            using (DbTransaction t = new DbTransaction(Settings.Default.SiteCarConnectionString, System.Data.IsolationLevel.ReadUncommitted))
            {
                t.Begin();
                result = new MakerModelDL(t).GetCarModels(makerId);
                t.Commit();
            }
            return result;
        }
        internal static List<BmCarModel> GetCarModels()
        {
            List<BmCarModel> result;
            using (DbTransaction t = new DbTransaction(Settings.Default.SiteCarConnectionString, System.Data.IsolationLevel.ReadUncommitted))
            {
                t.Begin();
                result = new MakerModelDL(t).GetCarModels();
                t.Commit();
            }
            return result;
        }

        public static void InsertOrUpdate(List<car_Makers> makers)
        {
            using (CarSiteEntities db = new CarSiteEntities())
            {
                foreach(car_Makers maker in  makers)
                {
                    car_Makers old = db.car_Makers.Where(row => row.RefId == maker.RefId).FirstOrDefault();
                    if (old == null)
                    {
                        maker.Updated = DateTime.UtcNow;
                        db.car_Makers.AddObject(maker);
                        db.SaveChanges();
                    }
                    else
                    {
                        maker.MakerId = old.MakerId;
                        db.ObjectStateManager.ChangeObjectState(old, EntityState.Unchanged);
                        db.car_Makers.ApplyCurrentValues(maker);
                        if (old.EntityState == EntityState.Modified)
                            old.Updated = DateTime.UtcNow;
                        db.SaveChanges();
                    }
                }
            }
        }

        public static Dictionary<string, int> GetRefId2MakerId()
        {
            using (CarSiteEntities db = new CarSiteEntities())
            {
                return db.car_Makers
                    .Select(row => new { RefId = row.RefId, MakerId = row.MakerId })
                    .ToDictionary(row => row.RefId, row => row.MakerId);
            }
        }

        public static void InsertOrUpdate(List<car_Models> models)
        {
            using (CarSiteEntities db = new CarSiteEntities())
            {
                foreach (car_Models model in models)
                {
                    car_Models old = db.car_Models.Where(row => row.RefId == model.RefId).FirstOrDefault();
                    if (old == null)
                    {
                        model.Updated = DateTime.UtcNow;
                        db.car_Models.AddObject(model);
                        db.SaveChanges();
                    }
                    else
                    {
                        model.ModelId = old.ModelId;
                        db.ObjectStateManager.ChangeObjectState(old, EntityState.Unchanged);
                        db.car_Models.ApplyCurrentValues(model);
                        if (old.EntityState == EntityState.Modified)
                            old.Updated = DateTime.UtcNow;
                        db.SaveChanges();
                    }
                }
            }
        }
    }
}
