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

public class FloatVector : global::System.IDisposable, global::System.Collections.IEnumerable
    , global::System.Collections.Generic.IList<float>
 {
  private global::System.Runtime.InteropServices.HandleRef swigCPtr;
  protected bool swigCMemOwn;

  internal FloatVector(global::System.IntPtr cPtr, bool cMemoryOwn) {
    swigCMemOwn = cMemoryOwn;
    swigCPtr = new global::System.Runtime.InteropServices.HandleRef(this, cPtr);
  }

  internal static global::System.Runtime.InteropServices.HandleRef getCPtr(FloatVector obj) {
    return (obj == null) ? new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero) : obj.swigCPtr;
  }

  ~FloatVector() {
    Dispose();
  }

  public virtual void Dispose() {
    lock(this) {
      if (swigCPtr.Handle != global::System.IntPtr.Zero) {
        if (swigCMemOwn) {
          swigCMemOwn = false;
          csharpaidiclientPINVOKE.delete_FloatVector(swigCPtr);
        }
        swigCPtr = new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero);
      }
      global::System.GC.SuppressFinalize(this);
    }
  }

  public FloatVector(global::System.Collections.ICollection c) : this() {
    if (c == null)
      throw new global::System.ArgumentNullException("c");
    foreach (float element in c) {
      this.Add(element);
    }
  }

  public bool IsFixedSize {
    get {
      return false;
    }
  }

  public bool IsReadOnly {
    get {
      return false;
    }
  }

  public float this[int index]  {
    get {
      return getitem(index);
    }
    set {
      setitem(index, value);
    }
  }

  public int Capacity {
    get {
      return (int)capacity();
    }
    set {
      if (value < size())
        throw new global::System.ArgumentOutOfRangeException("Capacity");
      reserve((uint)value);
    }
  }

  public int Count {
    get {
      return (int)size();
    }
  }

  public bool IsSynchronized {
    get {
      return false;
    }
  }

  public void CopyTo(float[] array)
  {
    CopyTo(0, array, 0, this.Count);
  }

  public void CopyTo(float[] array, int arrayIndex)
  {
    CopyTo(0, array, arrayIndex, this.Count);
  }

  public void CopyTo(int index, float[] array, int arrayIndex, int count)
  {
    if (array == null)
      throw new global::System.ArgumentNullException("array");
    if (index < 0)
      throw new global::System.ArgumentOutOfRangeException("index", "Value is less than zero");
    if (arrayIndex < 0)
      throw new global::System.ArgumentOutOfRangeException("arrayIndex", "Value is less than zero");
    if (count < 0)
      throw new global::System.ArgumentOutOfRangeException("count", "Value is less than zero");
    if (array.Rank > 1)
      throw new global::System.ArgumentException("Multi dimensional array.", "array");
    if (index+count > this.Count || arrayIndex+count > array.Length)
      throw new global::System.ArgumentException("Number of elements to copy is too large.");
    for (int i=0; i<count; i++)
      array.SetValue(getitemcopy(index+i), arrayIndex+i);
  }

  global::System.Collections.Generic.IEnumerator<float> global::System.Collections.Generic.IEnumerable<float>.GetEnumerator() {
    return new FloatVectorEnumerator(this);
  }

  global::System.Collections.IEnumerator global::System.Collections.IEnumerable.GetEnumerator() {
    return new FloatVectorEnumerator(this);
  }

  public FloatVectorEnumerator GetEnumerator() {
    return new FloatVectorEnumerator(this);
  }

  // Type-safe enumerator
  /// Note that the IEnumerator documentation requires an InvalidOperationException to be thrown
  /// whenever the collection is modified. This has been done for changes in the size of the
  /// collection but not when one of the elements of the collection is modified as it is a bit
  /// tricky to detect unmanaged code that modifies the collection under our feet.
  public sealed class FloatVectorEnumerator : global::System.Collections.IEnumerator
    , global::System.Collections.Generic.IEnumerator<float>
  {
    private FloatVector collectionRef;
    private int currentIndex;
    private object currentObject;
    private int currentSize;

    public FloatVectorEnumerator(FloatVector collection) {
      collectionRef = collection;
      currentIndex = -1;
      currentObject = null;
      currentSize = collectionRef.Count;
    }

    // Type-safe iterator Current
    public float Current {
      get {
        if (currentIndex == -1)
          throw new global::System.InvalidOperationException("Enumeration not started.");
        if (currentIndex > currentSize - 1)
          throw new global::System.InvalidOperationException("Enumeration finished.");
        if (currentObject == null)
          throw new global::System.InvalidOperationException("Collection modified.");
        return (float)currentObject;
      }
    }

    // Type-unsafe IEnumerator.Current
    object global::System.Collections.IEnumerator.Current {
      get {
        return Current;
      }
    }

    public bool MoveNext() {
      int size = collectionRef.Count;
      bool moveOkay = (currentIndex+1 < size) && (size == currentSize);
      if (moveOkay) {
        currentIndex++;
        currentObject = collectionRef[currentIndex];
      } else {
        currentObject = null;
      }
      return moveOkay;
    }

    public void Reset() {
      currentIndex = -1;
      currentObject = null;
      if (collectionRef.Count != currentSize) {
        throw new global::System.InvalidOperationException("Collection modified.");
      }
    }

    public void Dispose() {
        currentIndex = -1;
        currentObject = null;
    }
  }

  public void Clear() {
    csharpaidiclientPINVOKE.FloatVector_Clear(swigCPtr);
  }

  public void Add(float x) {
    csharpaidiclientPINVOKE.FloatVector_Add(swigCPtr, x);
  }

  private uint size() {
    uint ret = csharpaidiclientPINVOKE.FloatVector_size(swigCPtr);
    return ret;
  }

  private uint capacity() {
    uint ret = csharpaidiclientPINVOKE.FloatVector_capacity(swigCPtr);
    return ret;
  }

  private void reserve(uint n) {
    csharpaidiclientPINVOKE.FloatVector_reserve(swigCPtr, n);
  }

  public FloatVector() : this(csharpaidiclientPINVOKE.new_FloatVector__SWIG_0(), true) {
  }

  public FloatVector(FloatVector other) : this(csharpaidiclientPINVOKE.new_FloatVector__SWIG_1(FloatVector.getCPtr(other)), true) {
    if (csharpaidiclientPINVOKE.SWIGPendingException.Pending) throw csharpaidiclientPINVOKE.SWIGPendingException.Retrieve();
  }

  public FloatVector(int capacity) : this(csharpaidiclientPINVOKE.new_FloatVector__SWIG_2(capacity), true) {
    if (csharpaidiclientPINVOKE.SWIGPendingException.Pending) throw csharpaidiclientPINVOKE.SWIGPendingException.Retrieve();
  }

  private float getitemcopy(int index) {
    float ret = csharpaidiclientPINVOKE.FloatVector_getitemcopy(swigCPtr, index);
    if (csharpaidiclientPINVOKE.SWIGPendingException.Pending) throw csharpaidiclientPINVOKE.SWIGPendingException.Retrieve();
    return ret;
  }

  private float getitem(int index) {
    float ret = csharpaidiclientPINVOKE.FloatVector_getitem(swigCPtr, index);
    if (csharpaidiclientPINVOKE.SWIGPendingException.Pending) throw csharpaidiclientPINVOKE.SWIGPendingException.Retrieve();
    return ret;
  }

  private void setitem(int index, float val) {
    csharpaidiclientPINVOKE.FloatVector_setitem(swigCPtr, index, val);
    if (csharpaidiclientPINVOKE.SWIGPendingException.Pending) throw csharpaidiclientPINVOKE.SWIGPendingException.Retrieve();
  }

  public void AddRange(FloatVector values) {
    csharpaidiclientPINVOKE.FloatVector_AddRange(swigCPtr, FloatVector.getCPtr(values));
    if (csharpaidiclientPINVOKE.SWIGPendingException.Pending) throw csharpaidiclientPINVOKE.SWIGPendingException.Retrieve();
  }

  public FloatVector GetRange(int index, int count) {
    global::System.IntPtr cPtr = csharpaidiclientPINVOKE.FloatVector_GetRange(swigCPtr, index, count);
    FloatVector ret = (cPtr == global::System.IntPtr.Zero) ? null : new FloatVector(cPtr, true);
    if (csharpaidiclientPINVOKE.SWIGPendingException.Pending) throw csharpaidiclientPINVOKE.SWIGPendingException.Retrieve();
    return ret;
  }

  public void Insert(int index, float x) {
    csharpaidiclientPINVOKE.FloatVector_Insert(swigCPtr, index, x);
    if (csharpaidiclientPINVOKE.SWIGPendingException.Pending) throw csharpaidiclientPINVOKE.SWIGPendingException.Retrieve();
  }

  public void InsertRange(int index, FloatVector values) {
    csharpaidiclientPINVOKE.FloatVector_InsertRange(swigCPtr, index, FloatVector.getCPtr(values));
    if (csharpaidiclientPINVOKE.SWIGPendingException.Pending) throw csharpaidiclientPINVOKE.SWIGPendingException.Retrieve();
  }

  public void RemoveAt(int index) {
    csharpaidiclientPINVOKE.FloatVector_RemoveAt(swigCPtr, index);
    if (csharpaidiclientPINVOKE.SWIGPendingException.Pending) throw csharpaidiclientPINVOKE.SWIGPendingException.Retrieve();
  }

  public void RemoveRange(int index, int count) {
    csharpaidiclientPINVOKE.FloatVector_RemoveRange(swigCPtr, index, count);
    if (csharpaidiclientPINVOKE.SWIGPendingException.Pending) throw csharpaidiclientPINVOKE.SWIGPendingException.Retrieve();
  }

  public static FloatVector Repeat(float value, int count) {
    global::System.IntPtr cPtr = csharpaidiclientPINVOKE.FloatVector_Repeat(value, count);
    FloatVector ret = (cPtr == global::System.IntPtr.Zero) ? null : new FloatVector(cPtr, true);
    if (csharpaidiclientPINVOKE.SWIGPendingException.Pending) throw csharpaidiclientPINVOKE.SWIGPendingException.Retrieve();
    return ret;
  }

  public void Reverse() {
    csharpaidiclientPINVOKE.FloatVector_Reverse__SWIG_0(swigCPtr);
  }

  public void Reverse(int index, int count) {
    csharpaidiclientPINVOKE.FloatVector_Reverse__SWIG_1(swigCPtr, index, count);
    if (csharpaidiclientPINVOKE.SWIGPendingException.Pending) throw csharpaidiclientPINVOKE.SWIGPendingException.Retrieve();
  }

  public void SetRange(int index, FloatVector values) {
    csharpaidiclientPINVOKE.FloatVector_SetRange(swigCPtr, index, FloatVector.getCPtr(values));
    if (csharpaidiclientPINVOKE.SWIGPendingException.Pending) throw csharpaidiclientPINVOKE.SWIGPendingException.Retrieve();
  }

  public bool Contains(float value) {
    bool ret = csharpaidiclientPINVOKE.FloatVector_Contains(swigCPtr, value);
    return ret;
  }

  public int IndexOf(float value) {
    int ret = csharpaidiclientPINVOKE.FloatVector_IndexOf(swigCPtr, value);
    return ret;
  }

  public int LastIndexOf(float value) {
    int ret = csharpaidiclientPINVOKE.FloatVector_LastIndexOf(swigCPtr, value);
    return ret;
  }

  public bool Remove(float value) {
    bool ret = csharpaidiclientPINVOKE.FloatVector_Remove(swigCPtr, value);
    return ret;
  }

}

}
