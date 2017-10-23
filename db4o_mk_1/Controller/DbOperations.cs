using db4o_mk_1.Model;
using Db4objects.Db4o;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace db4o_mk_1.Controller
{
    public class DbOperations
    {
        static public IObjectContainer Context { get; set; }
        static public string DbName = "db4o.db";
        
        static public void Open()
        {
            try
            {
                Context = Db4oEmbedded.OpenFile(DbName);
            }
            catch
            { 
                Close();
            }

            Context.Ext().Configure().ObjectClass(typeof(Person)).CascadeOnDelete(true);
            Context.Ext().Configure().ObjectClass(typeof(Person)).CascadeOnUpdate(true);
            Context.Ext().Configure().ObjectClass(typeof(Phone)).CascadeOnDelete(true);
        }

        static public void Close()
        {
            Context.Close();
        }

        static public void Save(object obj)
        {
             Context.Store(obj);
        }

        static public void Delete(object obj)
        {
            Context.Delete(obj);
        }

    }
}
