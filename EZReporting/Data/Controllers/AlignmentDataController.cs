using System.Collections.Generic;
using System.Linq;
using EZDataFramework.Framework;

namespace EZReporting.Data {
    public class AlignmentDataController : DataControllerBase {

        public static Alignment AddAlignment(Alignment alignment) {
            using(var entities = new EZReportingEntities()) {
                entities.Alignments.Add(alignment);
                return alignment;
            }
        }

        public static void DeleteAlignment(Alignment alignment) {
            using(var entities = new EZReportingEntities()) {
                entities.Alignments.Remove(alignment);
                entities.SaveChanges();
            }
        }

        public static void DeleteAlignment(int id) {
            using(var entities = new EZReportingEntities()) {
                var current = entities.Alignments.Find(id);
                if(current == null)
                    return;
                entities.Alignments.Remove(current);
                entities.SaveChanges();
            }
        }

        public static Alignment GetAlignment(int id) {
            using(var entities = new EZReportingEntities()) {
                return entities.Alignments.Find(id);
            }
        }

        public static IEnumerable<Alignment> GetAlignment(string displayName) {
            using(var entities = new EZReportingEntities()) {
                return from   entity in entities.Alignments
                       where  entity.DisplayName == displayName
                       select entity;
            }
        }
    }
}
