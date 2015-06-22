using System;

namespace MCSD._1_Manage_program_flow._1._4 {
  class Events {
    public event Action OnWhatever = delegate { };

    protected virtual void OnOnWhatever() {
      var handler = OnWhatever;
      if ( handler != null ) {
        handler();
      } 
    }
  }
}
