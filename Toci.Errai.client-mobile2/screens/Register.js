import React, {useState} from 'react';
import {
  Alert,
  Text,
  TouchableOpacity,
  TextInput,
  View,
  StyleSheet,
} from 'react-native';
import {environment} from '../environment';

export default function Register({navigation}) {
  const [firstname, setFirstname] = useState('');
  const [lastname, setLastname] = useState('');
  const [email, setEmail] = useState('');
  const [password, setPassword] = useState('');

  const onRegister = async () => {
    //const {firstname, lastname, email, password} = this.state;
    console.log(firstname, lastname, email, password);
    let response = await fetch(environment.apiUrl + 'api/Account/register', {
      method: 'POST',
      headers: {
        Accept: 'application/json',
        'Content-Type': 'application/json',
      },
      body: JSON.stringify({firstname, lastname, email, password}),
    });
    let json = await response.json();
    console.log(json);
  };
  return (
    <View style={styles.container}>
      <TextInput
        value={firstname}
        onChangeText={text => setFirstname(text)}
        placeholder="firstname"
        placeholderTextColor="white"
        style={styles.input}
      />
      <TextInput
        value={lastname}
        onChangeText={text => setLastname(text)}
        placeholder="lastname"
        placeholderTextColor="white"
        style={styles.input}
      />
      <TextInput
        value={email}
        keyboardType="email-address"
        onChangeText={text => setEmail(text)}
        placeholder="email"
        placeholderTextColor="white"
        style={styles.input}
      />
      <TextInput
        value={password}
        onChangeText={text => setPassword(text)}
        placeholder={'password'}
        secureTextEntry={true}
        placeholderTextColor="white"
        style={styles.input}
      />

      <TouchableOpacity style={styles.button} onPress={() => onRegister()}>
        <Text style={styles.buttonText}> Register </Text>
      </TouchableOpacity>
      <Text style={{marginTop: '2%', fontSize: 15}}>Have already an account?</Text>

      <TouchableOpacity>
        <Text style={{fontSize: 20, fontWeight: 'bold'}} onPress={() => navigation.navigate('Login')}>Back to login</Text>
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
});