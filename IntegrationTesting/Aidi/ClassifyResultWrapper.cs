//------------------------------------------------------------------------------
// <auto-generated />
//
// This file was automatically generated by SWIG (http://www.swig.org).
// Version 3.0.12
//
// Do not make changes to this file unless you know what you are doing--modify
// the SWIG interface file instead.
//------------------------------------------------------------------------------

namespace Aqrose.Aidi {

public class ClassifyResultWrapper : global::System.IDisposable {
  private global::System.Runtime.InteropServices.HandleRef swigCPtr;
  protected bool swigCMemOwn;

  internal ClassifyResultWrapper(global::System.IntPtr cPtr, bool cMemoryOwn) {
    swigCMemOwn = cMemoryOwn;
    swigCPtr = new global::System.Runtime.InteropServices.HandleRef(this, cPtr);
  }

  internal static global::System.Runtime.InteropServices.HandleRef getCPtr(ClassifyResultWrapper obj) {
    return (obj == null) ? new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero) : obj.swigCPtr;
  }

  ~ClassifyResultWrapper() {
    Dispose();
  }

  public virtual void Dispose() {
    lock(this) {
      if (swigCPtr.Handle != global::System.IntPtr.Zero) {
        if (swigCMemOwn) {
          swigCMemOwn = false;
          csharpaidiclientPINVOKE.delete_ClassifyResultWrapper(swigCPtr);
        }
        swigCPtr = new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero);
      }
      global::System.GC.SuppressFinalize(this);
    }
  }

  public double acc {
    set {
      csharpaidiclientPINVOKE.ClassifyResultWrapper_acc_set(swigCPtr, value);
    } 
    get {
      double ret = csharpaidiclientPINVOKE.ClassifyResultWrapper_acc_get(swigCPtr);
      return ret;
    } 
  }

  public double recall {
    set {
      csharpaidiclientPINVOKE.ClassifyResultWrapper_recall_set(swigCPtr, value);
    } 
    get {
      double ret = csharpaidiclientPINVOKE.ClassifyResultWrapper_recall_get(swigCPtr);
      return ret;
    } 
  }

  public ClassifyResultWrapper() : this(csharpaidiclientPINVOKE.new_ClassifyResultWrapper(), true) {
  }

}

}
