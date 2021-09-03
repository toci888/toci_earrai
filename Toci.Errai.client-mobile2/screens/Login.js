import React, {useState, useEffect } from 'react';
import {
  Alert,
  Text,
  TouchableOpacity,
  TextInput,
  View,
  StyleSheet,
} from 'react-native';
import {environment} from '../environment';
import AppUser from '../shared/AppUser';

export default function Login({navigation}) {

  const [email, setEmail] = useState('');
  const [password, setPassword] = useState('');

  const checkIfLogged = async () => {
    let logged = await AppUser.checkIfAlreadyExists()
      navigation.navigate('Home');
  }

  useEffect(() => {
    checkIfLogged()
  }, [])

  const onLogin = async () => {
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

    if(json != "Invalid username or password")
    {
        navigation.navigate('Home');
    }
  };

  return (
    <View style={styles.container}>
      <TextInput value={email} keyboardType="email-address" onChangeText={text => setEmail(text)}
        placeholder="E-Mail" placeholderTextColor="#aaa" style={styles.input}/>
      <TextInput value={password} onChangeText={text => setPassword(text)} placeholder={'Password'}
        secureTextEntry={true} placeholderTextColor="#aaa" style={styles.input}/>

      <TouchableOpacity style={styles.button} onPress={() => onLogin()}>
        <Text style={styles.buttonText}> Login </Text>
      </TouchableOpacity>

      <Text style={{marginTop: '2%', fontSize: 15}}>Not have an account?</Text>

      <TouchableOpacity>
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
    backgroundColor: '#ddd',
  },
  button: {
    alignItems: 'center',
    width: 200,
    height: 44,
    padding: 5,
    borderWidth: 1,
    borderColor: '#8781d8',
    // borderRadius: 25,
    marginTop: 10,
    backgroundColor: '#8781d8'
  },
  buttonText: {
    //fontFamily: 'Baskerville',
    fontSize: 20,
    alignItems: 'center',
    justifyContent: 'center',
    fontWeight: 'bold',
    color: '#ddd'
  },
  input: {
    width: 200,
    //fontFamily: 'Baskerville',
    backgroundColor: '#ddd',
    fontSize: 20,
    height: 44,
    padding: 10,
    borderWidth: 1,
    borderColor: '#777',
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