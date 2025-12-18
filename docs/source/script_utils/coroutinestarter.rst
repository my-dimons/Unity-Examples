CoroutineStarter
==========

**NAMESPACE:**
   `UnityUtils.ScriptUtils`
     
The **CoroutineStarter** script is used to start coroutines in a static class.

Example Usage
-------------
.. code:: csharp
  
   using UnityEngine;
   using UnityUtils.ScriptUtils;
   using System;
   using System.Collections;
   
   public static class ExampleScript
   {
   	void ExampleFunction()
   	{
   	   // Starts a normal coroutine
   	   CoroutineStarter.Starter.StartCoroutine(ExampleCoroutine());
   	   
   	   // Starts a coroutine that won't stop on scene change (Be careful when using this, can cause lots of errors)
   	   CoroutineStarter.PersistantStarter.StartCoroutine(ExampleCoroutine());
   	}
   	
   	public IEnumerator ExampleCoroutine()
   	{
   	   yield return new WaitForSeconds(3f);
   	   Debug.Log("Coroutine Ended");
   	}
   }  
Functions
---------

.. doxygenclass:: UnityUtils::ScriptUtils::CoroutineStarter
   :members: