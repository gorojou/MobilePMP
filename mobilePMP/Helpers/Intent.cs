using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace mobilePMP.Helpers
{
    

    public class Intent
    {
        public class NavigationImage
        {

            public static Intent Intent { get; set; }
        }

        public Page _startPage
        {
            get;
            set;
        }

        public Page _endPage
        {
            get;
            set;
        }


        public Dictionary<string, object> DataObject{
            get;
            set;
        }

        public Dictionary<string, string> DataString
        {
            get;
            set;
        }

        public Intent(Page startPage, Page endPage)
        {

            _startPage = startPage;
            _endPage = endPage;
            DataObject = new Dictionary<string, object>();
        }

        public T GetObject<T>(string key)
        {
            if (DataObject.ContainsKey(key)){

                return (T)DataObject[key];

            }throw new ArgumentException("La llave ya existe");
             
        }
        public string GetString<T>(string key)
        {
            if (DataString.ContainsKey(key))
            {

                return DataString[key];

            }
            throw new ArgumentException("La llave ya existe");

        }

        public void PutObject(string key, object obj){

            if (DataObject.ContainsKey(key))
            {
                throw new ArgumentException("La llave ya existe");
            }
            DataObject.Add(key, obj);

        }

        public void PutString (string key, string value){
            if (DataString.ContainsKey(key))
            { 
                throw new ArgumentException("La llave ya existe");
            }
            DataString.Add(key, value);
        }

        public void StartIntent(){
            NavigationImage.Intent = this;   
            _startPage.Navigation.PushModalAsync(_endPage, true);
        }


    }
}
