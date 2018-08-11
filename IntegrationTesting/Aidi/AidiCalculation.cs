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

public class AidiCalculation : global::System.IDisposable {
  private global::System.Runtime.InteropServices.HandleRef swigCPtr;
  protected bool swigCMemOwn;

  internal AidiCalculation(global::System.IntPtr cPtr, bool cMemoryOwn) {
    swigCMemOwn = cMemoryOwn;
    swigCPtr = new global::System.Runtime.InteropServices.HandleRef(this, cPtr);
  }

  internal static global::System.Runtime.InteropServices.HandleRef getCPtr(AidiCalculation obj) {
    return (obj == null) ? new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero) : obj.swigCPtr;
  }

  ~AidiCalculation() {
    Dispose();
  }

  public virtual void Dispose() {
    lock(this) {
      if (swigCPtr.Handle != global::System.IntPtr.Zero) {
        if (swigCMemOwn) {
          swigCMemOwn = false;
          csharpaidiclientPINVOKE.delete_AidiCalculation(swigCPtr);
        }
        swigCPtr = new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero);
      }
      global::System.GC.SuppressFinalize(this);
    }
  }

  public AidiCalculation() : this(csharpaidiclientPINVOKE.new_AidiCalculation(), true) {
  }

  public LocationResultWrapper get_location_result(string label_file_path, string test_result_file_path, int sample_number) {
    LocationResultWrapper ret = new LocationResultWrapper(csharpaidiclientPINVOKE.AidiCalculation_get_location_result__SWIG_0(swigCPtr, label_file_path, test_result_file_path, sample_number), true);
    if (csharpaidiclientPINVOKE.SWIGPendingException.Pending) throw csharpaidiclientPINVOKE.SWIGPendingException.Retrieve();
    return ret;
  }

  public LocationResultWrapper get_location_result(string label_file_path, string test_result_file_path, IntVector indexs) {
    LocationResultWrapper ret = new LocationResultWrapper(csharpaidiclientPINVOKE.AidiCalculation_get_location_result__SWIG_1(swigCPtr, label_file_path, test_result_file_path, IntVector.getCPtr(indexs)), true);
    if (csharpaidiclientPINVOKE.SWIGPendingException.Pending) throw csharpaidiclientPINVOKE.SWIGPendingException.Retrieve();
    return ret;
  }

  public DefectDetectResultWrapper get_detect_result(string label_file_path, string test_result_file_path, int sample_number) {
    DefectDetectResultWrapper ret = new DefectDetectResultWrapper(csharpaidiclientPINVOKE.AidiCalculation_get_detect_result__SWIG_0(swigCPtr, label_file_path, test_result_file_path, sample_number), true);
    if (csharpaidiclientPINVOKE.SWIGPendingException.Pending) throw csharpaidiclientPINVOKE.SWIGPendingException.Retrieve();
    return ret;
  }

  public DefectDetectResultWrapper get_detect_result(string label_file_path, string test_result_file_path, IntVector indexs) {
    DefectDetectResultWrapper ret = new DefectDetectResultWrapper(csharpaidiclientPINVOKE.AidiCalculation_get_detect_result__SWIG_1(swigCPtr, label_file_path, test_result_file_path, IntVector.getCPtr(indexs)), true);
    if (csharpaidiclientPINVOKE.SWIGPendingException.Pending) throw csharpaidiclientPINVOKE.SWIGPendingException.Retrieve();
    return ret;
  }

  public ClassifyResultWrapper get_classify_result(string label_file_path, string test_result_file_path, int sample_number) {
    ClassifyResultWrapper ret = new ClassifyResultWrapper(csharpaidiclientPINVOKE.AidiCalculation_get_classify_result__SWIG_0(swigCPtr, label_file_path, test_result_file_path, sample_number), true);
    if (csharpaidiclientPINVOKE.SWIGPendingException.Pending) throw csharpaidiclientPINVOKE.SWIGPendingException.Retrieve();
    return ret;
  }

  public ClassifyResultWrapper get_classify_result(string label_file_path, string test_result_file_path, IntVector indexs) {
    ClassifyResultWrapper ret = new ClassifyResultWrapper(csharpaidiclientPINVOKE.AidiCalculation_get_classify_result__SWIG_1(swigCPtr, label_file_path, test_result_file_path, IntVector.getCPtr(indexs)), true);
    if (csharpaidiclientPINVOKE.SWIGPendingException.Pending) throw csharpaidiclientPINVOKE.SWIGPendingException.Retrieve();
    return ret;
  }

  public FeatureLocationResultWrapper get_feature_location_result(string label_file_path, string test_result_file_path, StringIntMap label_dict, IntVector indexs) {
    FeatureLocationResultWrapper ret = new FeatureLocationResultWrapper(csharpaidiclientPINVOKE.AidiCalculation_get_feature_location_result(swigCPtr, label_file_path, test_result_file_path, StringIntMap.getCPtr(label_dict), IntVector.getCPtr(indexs)), true);
    if (csharpaidiclientPINVOKE.SWIGPendingException.Pending) throw csharpaidiclientPINVOKE.SWIGPendingException.Retrieve();
    return ret;
  }

}

}
