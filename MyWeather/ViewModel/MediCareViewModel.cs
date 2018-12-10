using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using MvvmHelpers;
using MyWeather.Helpers;
using MyWeather.Model;
using MyWeather.Models;
using MyWeather.Services;
using Plugin.Permissions;
using Plugin.Permissions.Abstractions;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace MyWeather.ViewModel
{
    class MediCareViewModel: BaseViewModel
    {
        private MediCareService MediCareService { get; } = new MediCareService();

        int _drugId = 1;
        public int DrugId
        {
            get { return _drugId; }
            set { SetProperty(ref _drugId, value); }
        }
        
        int _prescriptionId = 1;
        public int PrescriptionId
        {
            get { return _prescriptionId; }
            set { SetProperty(ref _prescriptionId, value); }
        }

        string _drugName = string.Empty;
        public string DrugName
        {
            get { return _drugName; }
            set { SetProperty(ref _drugName, value); }
        }

        string _availableNumber = string.Empty;
        public string AvailableNumber
        {
            get { return _availableNumber; }
            set { SetProperty(ref _availableNumber, value); ; }
        } 
        
        string _drugType = string.Empty;
        public string DrugType
        {
            get { return _drugType; }
            set { SetProperty(ref _drugType, value); ; }
        }  
        
        string _commonInTake = string.Empty;
        public string CommonInTake
        {
            get { return _commonInTake; }
            set { SetProperty(ref _commonInTake, value); ; }
        }

        List<Drug> drugList;
        public List<Drug> DrugList
        {
            get { return drugList; }
            set { drugList = value; OnPropertyChanged(); }
        }

        //Program pp = new Program();

        //public Drug DrugInfo
        //{
        //    get
        //    {
        //        pp.TriggerJob();
        //        return Program.lapaki;
        //    }
        //} 

        ICommand getDrug;
        public ICommand GetDrugCommand =>
            getDrug ??
                (getDrug = new Command(async () => await ExecuteGetDrugCommand()));

        private async Task ExecuteGetDrugCommand()
        {
            if (IsBusy)
                return;

            IsBusy = true;
            try
            {
                Drug drug = null;

                    drug = await MediCareService.GetDrug(DrugId);

                //Get forecast based on cityId

                DrugName = $"Drug Name: {drug?.DrugName}";
                DrugType = $"{drug.DrugType}: {drug?.DrugType}";

                DrugList = await MediCareService.GetAllDrugs();

                await TextToSpeech.SpeakAsync(DrugName);
            }
            catch (Exception ex)
            {
                DrugName = "Unable to get Drug Details";
                System.Diagnostics.Debug.WriteLine(ex.Message);
            }
            finally
            {
                IsBusy = false;
            }
        }

        private string _pDrugName = string.Empty;
        private int _pQuantity = 0;
        private string _pdrugType = string.Empty;
        private string _pIntakeTimeFrame = string.Empty;
        private string _pDisease = string.Empty;
        private string _pNumberofDays = string.Empty;
        public string pDrugName
        {
            get { return _pDrugName; }
            set { SetProperty(ref _pDrugName, value); }
        }
        public int pQuantity
        {
            get { return _pQuantity; }
            set { SetProperty(ref _pQuantity, value); }
        }public string pDrugType
        {
            get { return _pdrugType; }
            set { SetProperty(ref _pdrugType, value); }
        }public string pIntakeTimeFrame
        {
            get { return _pIntakeTimeFrame; }
            set { SetProperty(ref _pIntakeTimeFrame, value); }
        }public string pDisease
        {
            get { return _pDisease; }
            set { SetProperty(ref _pDisease, value); }
        }public string pNumberofDays
        {
            get { return _pNumberofDays; }
            set { SetProperty(ref _pNumberofDays, value); }
        }

        List<Prescription> prescriptionList;
        public List<Prescription> PrescriptionList
        {
            get { return prescriptionList; }
            set { prescriptionList = value; OnPropertyChanged(); }
        }

        ICommand getPrescription;
        public ICommand GetPrescriptionCommand =>
            getPrescription ??
            (getPrescription = new Command(async () => await ExecuteGetPrescriptionCommand()));

        internal async Task ExecuteGetPrescriptionCommand()
        {
            if (IsBusy)
                return;

            IsBusy = true;
            try
            {
                Prescription prescription = null;

                prescription = await MediCareService.GetPrescription(PrescriptionId);

                //Get forecast based on cityId

                pDrugName = $"Drug Name: {prescription?.DrugName}";
                pDrugType = $"{prescription.DrugType}: {prescription?.DrugType}";

                PrescriptionList = await MediCareService.GetAllPrescriptions();

                await TextToSpeech.SpeakAsync(pDrugName);
            }
            catch (Exception ex)
            {
                DrugName = "Unable to get Prescription Details";
                System.Diagnostics.Debug.WriteLine(ex.Message);
            }
            finally
            {
                IsBusy = false;
            }
        }
    }
}
