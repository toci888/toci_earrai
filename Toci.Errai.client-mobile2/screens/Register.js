import React, { Component } from 'react';
import { Alert, Text, TouchableOpacity, TextInput, View, StyleSheet } from 'react-native';
import { environment } from '../environment';

export default class Register extends Component {

    state = {
        firstname: '',
        lastname: '',
        email: '',
        password: '',
    };

    onRegister = async () => {
        const { firstname, lastname, email, password } = this.state;
        console.log(firstname, lastname, email, password);
        let response = await fetch(environment.apiUrl + 'api/Account/register', {
            method: 'POST',
            headers: {
                Accept: 'application/json',
                'Content-Type': 'application/json'
            },
            body: JSON.stringify({firstname, lastname, email,password})
        });
        let json = await response.json();
        console.log(json);
    };

    render() {
        return (
            <View style={styles.container}>
            <TextInput value={this.state.firstname} onChangeText={(firstname) => this.setState({ firstname })}
                placeholder='firstname' placeholderTextColor = 'white' style={styles.input}/>
            <TextInput value={this.state.lastname} onChangeText={(lastname) => this.setState({ lastname })}
                placeholder='lastname' placeholderTextColor = 'white' style={styles.input}/>
            <TextInput value={this.state.email} keyboardType = 'email-address' onChangeText={(email) => this.setState({ email })}
                placeholder='email' placeholderTextColor = 'white' style={styles.input}/>
            <TextInput value={this.state.password} onChangeText={(password) => this.setState({ password })} placeholder={'password'}
                secureTextEntry={true} placeholderTextColor = 'white' style={styles.input}/>
            
            <TouchableOpacity style={styles.button} onPress={this.onRegister.bind(this)}>
                <Text style={styles.buttonText}> Register </Text>
            </TouchableOpacity>
            </View>
        );
  }
}

const styles = StyleSheet.create({
  container: {
    flex: 1,
    alignItems: 'center',
    justifyContent: 'center',
    backgroundColor: 'gray',
  },
  titleText:{
    fontFamily: 'Baskerville',
    fontSize: 50,
    alignItems: 'center',
    justifyContent: 'center',
  },
  button: {
    alignItems: 'center',
    backgroundColor: 'powderblue',
    width: 200,
    height: 44,
    padding: 10,
    borderWidth: 1,
    borderColor: 'white',
    borderRadius: 25,
    marginBottom: 10,
  },
  buttonText:{
    fontFamily: 'Baskerville',
    fontSize: 20,
    alignItems: 'center',
    justifyContent: 'center',
  },
  input: {
    width: 200,
    fontFamily: 'Baskerville',
    fontSize: 20,
    height: 44,
    padding: 10,
    borderWidth: 1,
    borderColor: 'black',
    marginVertical: 10,
  },
});
