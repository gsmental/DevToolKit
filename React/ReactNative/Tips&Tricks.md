###Tips
* **SafeAreaView** -- use SafeAreaView intead of View for fullScreenView Page, it will visible properly in Android/iOS
* **Text numberOfLines={1}** will truncate text if cross more than one line **This Is a Example of trancate tex...**
* **Platform Specific code**  import Platform,StatusBar from react-native  : PaddingTop: Platform.OS==="android" ? StatusBar.currentHeight :0 
