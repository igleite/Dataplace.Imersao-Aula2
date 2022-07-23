using C1.Win.C1TrueDBGrid;
using Dataplace.Core.win.Controls.Behaviors;
using Dataplace.Core.win.Controls.Behaviors.Contracts;
using Dataplace.Core.win.Views.Controllers;
using System;

namespace Dataplace.Imersao.Presentation.Views.Orcamentos.Behaviors
{
    internal class FastInputGridBehavior : BehaviorBase, IBehavior
    {
        #region fields
        private Func<Configuration> _configurationMethod;
        private Configuration _configuration;
        #endregion


        #region constructors
        public FastInputGridBehavior(Func<Configuration> configurationMethod)
        {
            this._configurationMethod = configurationMethod;
        }
        #endregion

        #region methods
        public override void Configure()
        {
            _configuration = _configurationMethod.Invoke();

            _configuration.Grid.KeyDown += (object sender, System.Windows.Forms.KeyEventArgs e) =>
            {
                if (_configuration.Grid.FilterActive)
                    return;

                if (e.KeyCode == System.Windows.Forms.Keys.Return)
                {
                    var dc = _configuration.Grid.Splits[0].DisplayColumns[_configuration.Grid.Col];
                    if(dc == _configuration.Column)
                    {
                        if (dc.DataColumn.DataChanged)
                            if (_configuration.Controller.Update())
                                _configuration.Controller.Add();
                    }
                }


            };

        }

        #endregion


        #region config
        public class Configuration {
            private readonly RegisterViewController controller;
            private C1TrueDBGrid grid;
            private C1DisplayColumn c1DisplayColumn;

            public Configuration()
            {

            }

            public Configuration(RegisterViewController controller,  C1TrueDBGrid grid, C1DisplayColumn c1DisplayColumn)
            {
                this.controller = controller;
                this.grid = grid;
                this.c1DisplayColumn = c1DisplayColumn;
            }

            public RegisterViewController Controller => controller;
            public C1TrueDBGrid Grid => grid;
            public C1DisplayColumn Column => c1DisplayColumn;
        }
        #endregion
    }
}
