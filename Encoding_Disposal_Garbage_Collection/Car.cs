using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Encoding_Disposal_Garbage_Collection
{
    class Car : IDisposable
    {
        ArrayList routs = new ArrayList();
        public string Name
        {
            get;
            set;
        }
        public int MaxSpeed
        {
            get;
            set;
        }        
        public void TimeToTravell(Rout rout)
        {
            routs.Add(rout);
            var time = (int)((float)rout.distance / MaxSpeed * 60);
            Console.WriteLine($"Time to travell from {rout.city_A} to {rout.city_B} is {time} minutes");
        }

        #region IDisposable Support
        private bool disposedValue = false; // To detect redundant calls

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: dispose managed state (managed objects).                   
                }

                // TODO: free unmanaged resources (unmanaged objects) and override a finalizer below.
                // TODO: set large fields to null.
                routs = null;
                disposedValue = true;
            }
        }

        // TODO: override a finalizer only if Dispose(bool disposing) above has code to free unmanaged resources.
        ~Car()
        {
            // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
            Dispose(false);
        }

        // This code added to correctly implement the disposable pattern.
        public void Dispose()
        {
            // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
            Dispose(true);
            // TODO: uncomment the following line if the finalizer is overridden above.
            GC.SuppressFinalize(this);
            Console.WriteLine("Car was disposed!");
        }
        #endregion


    }
}
