using System;

namespace Demo08.Code {
    public class CustomerCreationException : Exception {
        public CustomerCreationException(Exception exception) : base("error", exception) {

        }
    }
}