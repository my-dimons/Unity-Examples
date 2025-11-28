UIUtilsManager
==========

**NAMESPACE:**
   `UnityUtils.ScriptUtils.UI`
     
The **UIUtilsManager** script is used to help with animating buttons

Example Usage
-------------
.. code:: csharp
  
   using UnityEngine;
   using UnityUtils.ScriptUtils.UI;
   
   public class ExampleScript : MonoBehaviour
   {
	public AnimationCurve SizingCurve;
   	void Start()
   	{
   	  // Will animate a button from a scale of (1, 1, 1) to (2, 2, 2) in a time of 1 second.
   	  StartCoroutine(UIUtilsManager.AnimateButtonSize(this.gameObject, new Vector3(1, 1, 1), new Vector3(2, 2, 2), SizingCurve, UIUtilsManager.CalculateAnimationSpeed(1)));
   	}
  }
Functions
---------

.. doxygenclass:: UnityUtils::ScriptUtils::UI::UIUtilsManager
   :members: