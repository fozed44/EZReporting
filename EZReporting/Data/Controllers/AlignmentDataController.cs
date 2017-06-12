using System.Collections.Generic;
using System.Linq;
using EZDataFramework.Framework;

namespace EZReporting.Data {
    public class AlignmentDataController : DataControllerBase {

        public static Alignment AddAlignment(Alignment alignment) {
            Context.Alignments.Add(alignment);
            Context.SaveChanges();
            return alignment;
        }

        public static void DeleteAlignment(Alignment alignment) {
            Context.Alignments.Attach(alignment);
            Context.Alignments.Remove(alignment);
            Context.SaveChanges();
        }

        public static void DeleteAlignment(int id) {
            var current = Context.Alignments.Find(id);
            if(current == null)
                return;
            Context.Alignments.Remove(current);
            Context.SaveChanges();
        }

        public static Alignment GetAlignment(int id) {
            return Context.Alignments.Find(id);
        }

        public static IEnumerable<Alignment> GetAlignment(string displayName) {
            return from   entity in Context.Alignments
                    where  entity.DisplayName == displayName
                    select entity;
        }
    }
}
