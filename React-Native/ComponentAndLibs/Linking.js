//Add in Androidminifest.xml
//<activity android:name=".MainActivity" android:launchMode="singleTask">


import React, { useCallback } from "react";
import { Alert, Button, Linking, StyleSheet, View } from "react-native";

const supportedURL = "https://facebook.com";
const supportedsms= "sms:+123456789";
const supportedtel ="tel:+123456789"
const unsupportedURL = "slack://open?team=123456";

const OpenURLButton = ({ url, children }) => {
  const handlePress = useCallback(async () => {
    // Checking if the link is supported for links with custom URL scheme.
    const supported = await Linking.canOpenURL(url);

    if (supported) {
      // Opening the link with some app, if the URL scheme is "http" the web link should be opened
      // by some browser in the mobile
      await Linking.openURL(url);
    } else {
      Alert.alert(`Don't know how to open this URL: ${url}`);
    }
  }, [url]);

  return <Button title={children} onPress={handlePress} />;
};

const App = () => {
  return (
    <View style={styles.container}>
      <OpenURLButton url={supportedURL}>Open Url </OpenURLButton>
      <OpenURLButton url={supportedsms}>Open SMS</OpenURLButton>
      <OpenURLButton url={supportedtel}>Open Contact call</OpenURLButton>
      <OpenURLButton url={unsupportedURL}>Open Unsupported string</OpenURLButton>
    </View>
  );
};

export default App;

const styles = StyleSheet.create({
  container: { flex: 1, justifyContent: "center", alignItems: "center" },
});
