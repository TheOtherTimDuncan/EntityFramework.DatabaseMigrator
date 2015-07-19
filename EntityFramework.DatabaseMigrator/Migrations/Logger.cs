using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations.Infrastructure;
using System.Linq;
using System.Windows.Forms;

namespace EntityFramework.DatabaseMigrator.Migrations
{
    public class Logger : MigrationsLogger
    {
        protected TextBox _txt;

        public Logger(TextBox txt)
        {
            this._txt = txt;
        }

        public virtual void Write(string message)
        {
            _txt.AppendText(message);
        }

        public virtual void WriteLine()
        {
            _txt.AppendText(Environment.NewLine);
        }

        public virtual void WriteLine(string message)
        {
            Write(message);
            WriteLine();
        }

        public override void Info(string message)
        {
            WriteLine(message);
        }

        public override void Verbose(string message)
        {
            WriteLine(message);
        }

        public override void Warning(string message)
        {
            WriteLine(message);
        }
    }
}
