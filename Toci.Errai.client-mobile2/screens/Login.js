import React, {useState} from 'react';
import {
  Alert,
  Text,
  TouchableOpacity,
  TextInput,
  View,
  StyleSheet,
  Button,
} from 'react-native';
import {environment} from '../environment';
import Register from './Register';

export default function Login({navigation}) {

  const [email, setEmail] = useState('');
  const [password, setPassword] = useState('');

  const onLogin = async () => {
    //const {email, password} = this.state;
    console.log(`email: ${email} + password: ${password}`);
    let response = await fetch(environment.apiUrl + 'api/Account/login', {
      method: 'POST',
      headers: {
        Accept: 'application/json',
        'Content-Type': 'application/json',
      },
      body: JSON.stringify({email, password}),
    });
    let json = await response.json();
    console.log(json);
  };

  return (
    <View style={styles.container}>
      <TextInput
        value={email}
        keyboardType="email-address"
        onChangeText={text => setEmail(text)}
        placeholder="E-Mail"
        placeholderTextColor="white"
        style={styles.input}
      />
      <TextInput
        value={password}
        onChangeText={text => setPassword(text)}
        placeholder={'Password'}
        secureTextEntry={true}
        placeholderTextColor="white"
        style={styles.input}
      />

      <TouchableOpacity style={styles.button} onPress={() => onLogin()}>
        <Text style={styles.buttonText}> Login </Text>
      </TouchableOpacity>

      <Text style={{marginTop: '2%', fontSize: 15}}>Not have an account?</Text>

      <TouchableOpacity style={{marginTop: ''}}>
        <Text style={{fontSize: 20, fontWeight: 'bold'}} onPress={() => navigation.navigate('Register')}>Register now!</Text>
      </TouchableOpacity>
    </View>
  );
}

const styles = StyleSheet.create({
  container: {
    flex: 1,
    alignItems: 'center',
    justifyContent: 'center',
    //backgroundColor: 'gray',
    backgroundColor: '#ddd',
  },
  titleText: {
    fontFamily: 'Baskerville',
    fontSize: 50,
    alignItems: 'center',
    justifyContent: 'center',
  },
  button: {
    alignItems: 'center',
    // backgroundColor: 'powderblue',
    backgroundColor: 'cornflowerblue',
    width: 200,
    height: 44,
    padding: 5,
    borderWidth: 1,
    borderColor: 'black',
    //borderRadius: 25,
    marginTop: 10,
  },
  buttonText: {
    fontFamily: 'Baskerville',
    fontSize: 20,
    alignItems: 'center',
    justifyContent: 'center',
  },
  input: {
    width: 200,
    fontFamily: 'Baskerville',
    backgroundColor: '#777',
    fontSize: 20,
    height: 44,
    padding: 10,
    borderWidth: 1,
    borderColor: 'black',
    marginVertical: 10,
  },
  inputTextStyle: {
    backgroundColor: '#ddd',
    borderColor: '#777',
    color: '#000',
    letterSpacing: 0.5,
    paddingTop: 10,
    paddingBottom: 10,
    paddingLeft: 10,
    fontSize: 17,
  },
});