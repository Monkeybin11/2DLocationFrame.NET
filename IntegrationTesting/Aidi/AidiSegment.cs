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

public class AidiSegment : global::System.IDisposable {
  private global::System.Runtime.InteropServices.HandleRef swigCPtr;
  protected bool swigCMemOwn;

  internal AidiSegment(global::System.IntPtr cPtr, bool cMemoryOwn) {
    swigCMemOwn = cMemoryOwn;
    swigCPtr = new global::System.Runtime.InteropServices.HandleRef(this, cPtr);
  }

  internal static global::System.Runtime.InteropServices.HandleRef getCPtr(AidiSegment obj) {
    return (obj == null) ? new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero) : obj.swigCPtr;
  }

  ~AidiSegment() {
    Dispose();
  }

  public virtual void Dispose() {
    lock(this) {
      if (swigCPtr.Handle != global::System.IntPtr.Zero) {
        if (swigCMemOwn) {
          swigCMemOwn = false;
          csharpaidiclientPINVOKE.delete_AidiSegment(swigCPtr);
        }
        swigCPtr = new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero);
      }
      global::System.GC.SuppressFinalize(this);
    }
  }

  public AidiSegment(string check_code) : this(csharpaidiclientPINVOKE.new_AidiSegment__SWIG_0(check_code), true) {
    if (csharpaidiclientPINVOKE.SWIGPendingException.Pending) throw csharpaidiclientPINVOKE.SWIGPendingException.Retrieve();
  }

  public AidiSegment() : this(csharpaidiclientPINVOKE.new_AidiSegment__SWIG_1(), true) {
  }

  public void set_param(SegmentClientParamWrapper arg0) {
    csharpaidiclientPINVOKE.AidiSegment_set_param(swigCPtr, SegmentClientParamWrapper.getCPtr(arg0));
    if (csharpaidiclientPINVOKE.SWIGPendingException.Pending) throw csharpaidiclientPINVOKE.SWIGPendingException.Retrieve();
  }

  public void initial_test_model() {
    csharpaidiclientPINVOKE.AidiSegment_initial_test_model(swigCPtr);
  }

  public void set_threshold(float value) {
    csharpaidiclientPINVOKE.AidiSegment_set_threshold(swigCPtr, value);
  }

  public void set_filter_area(int min, int max) {
    csharpaidiclientPINVOKE.AidiSegment_set_filter_area(swigCPtr, min, max);
  }

  public void set_filter_width(int min, int max) {
    csharpaidiclientPINVOKE.AidiSegment_set_filter_width(swigCPtr, min, max);
  }

  public void set_filter_height(int min, int max) {
    csharpaidiclientPINVOKE.AidiSegment_set_filter_height(swigCPtr, min, max);
  }

  public AidiImage start_test(AidiImage source_image) {
    AidiImage ret = new AidiImage(csharpaidiclientPINVOKE.AidiSegment_start_test(swigCPtr, AidiImage.getCPtr(source_image)), true);
    if (csharpaidiclientPINVOKE.SWIGPendingException.Pending) throw csharpaidiclientPINVOKE.SWIGPendingException.Retrieve();
    return ret;
  }

}

}