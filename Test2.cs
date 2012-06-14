using org.apache.commons.logging;

class Test {
  static void Main (string[] args) {
    // Getting the Log instance will cause the program not to exit normally;
    // No actual logging is required.  Note that restricting execution further
    // (e.g. only the static initialization of LogFactory or only obtaining
    // a LogFactory class) will enable the program to exit.
    Log log = LogFactory.getLog("name");

    // this never works:
    // System.Environment.Exit(0);
    
    System.Console.WriteLine("exiting...");

    // this always works:
    java.lang.System.exit(0);
  }
}
