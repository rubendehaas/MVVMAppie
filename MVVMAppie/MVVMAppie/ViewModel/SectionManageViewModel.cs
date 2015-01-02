using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using MVVMAppie.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMAppie.ViewModel
{
    public class SectionManageViewModel :ViewModelBase
    {
        //Dit viewmodel is puur en alleen om alle content in het section manage window te handelen. Alle objecten die hierin getoond zijn zijn andere viewmodels.
        //In dit viewmodel staan ook alle Button en textbox afhandelingen

        //variabelen
        private Database datab;
        private SectionsVM _sections;
        //variabele die de add knop afhandeld
        private RelayCommand addSectionCommand;
        //Variabele die de textbox text bijhoud
        private string _textIn;

        //Property om de sections op te vragen
        public SectionsVM Sections
        {
            get
            {
                //Dit is het SectionsVM
                return _sections;
            }
        }
        //Deze handeld de Text in property af. Bij elke verandering wordt er opgeslagen in _textIn en gezecht dat de property veranderd.
        public String TextIn
        {
            get
            {
                return _textIn;
                ;
            }

            set
            {
                _textIn = value;
                RaisePropertyChanged("TextIn");
            }
        }

        //Deze handeld de knop add af.
        public RelayCommand AddSectionCommand
        {
            get
            {
                if (addSectionCommand == null)
                {
                    addSectionCommand = new RelayCommand(() =>
                    {
                        //zegt tegen het sections viewmodel dat er een section moet worden aangemaakt.
                        _sections.addSectionCommand(TextIn);
                        TextIn = "";
                    });
                }
                return addSectionCommand;
            }
        }

        //Constructor. De parameters worden door het IOC framework ingepusht. Daardoor loopt alles op 1 database object. En bestaan bepaalde viewmoddels maar 1x
        public SectionManageViewModel(Database datab, SectionsVM Sections)
        {
            this.datab = datab;
            this._sections = Sections;
        }
    }
}
