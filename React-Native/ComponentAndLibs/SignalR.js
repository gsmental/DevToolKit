import React, { Component } from 'react';
import { StyleSheet, Text, View, Alert, TextInput, Button, FlatList, List } from 'react-native';
const SignalR = require("@aspnet/signalr");

let connection = new SignalR.HubConnectionBuilder()
  .withUrl("https://informme.in/chatHub/")
  .build();


connection.start().then(() => connection.invoke("HelloWorld", "SignalR Status", "It is nice to know that SignalR is working on your device"));

export default class App extends React.Component {
  constructor(props) {
    super(props);
    this.state = { NickName:'', text: '', messages: [], hubConnection: null, };
  }

  componentDidMount = () => {
    connection.on('HelloWorld', (name, message) => {
      var MsgModel = { name: name, message: message }
      const messages = this.state.messages.concat([MsgModel]);
      this.setState({ messages });
      this.setState({ text: '' });
    });
  }


  onPressLearnMore = () => {
    connection.invoke("HelloWorld", this.state.NickName, this.state.text);
  }

  render() {
    return (
      <View style={styles.container}>
        <Text>Welcome to SignalR with React Native App</Text>
        
        <TextInput placeholder="Nick Name"
          style={{ height: 40, borderColor: 'gray', borderWidth: 1, width: 300 }}
          onChangeText={(NickName) => this.setState({ NickName })}
          value={this.state.NickName}
        />


        <TextInput placeholder="Type here Message"
          style={{ height: 40, borderColor: 'gray', borderWidth: 1, width: 300 }}
          onChangeText={(text) => this.setState({ text })}
          value={this.state.text}
        />

        <Button
          onPress={this.onPressLearnMore}
          title="Send"
          color="#841584"
          accessibilityLabel="Learn more about this purple button"
        />


        <FlatList
          data={this.state.messages}
          showsVerticalScrollIndicator={false}
          renderItem={({ item }) =>
            <View style={styles.flatview}>
              <Text style={styles.name}>{item.name}</Text>
              <Text style={styles.email}>{item.message}</Text>
            </View>
          }
          keyExtractor={item => item.email}
        />




      </View>
    );
  }
}

const styles = StyleSheet.create({
  container: {
    flex: 1,
    backgroundColor: '#fff',
    alignItems: 'center',
    justifyContent: 'center',
    marginTop: 50,
  },

  flatview: {
    justifyContent: 'center',
    paddingTop: 30,
    borderRadius: 2,
  },
  name: {

    fontSize: 18
  },
  email: {
    color: 'red'
  },
});
