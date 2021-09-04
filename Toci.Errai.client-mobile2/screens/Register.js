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
import RestClient from '../RestClient';

export default function Register({navigation}) {
  const [firstname, setFirstname] = useState('');
  const [lastname, setLastname] = useState('');
  const [email, setEmail] = useState('');
  const [password, setPassword] = useState('');

  const onRegister = async () => {
    //const {firstname, lastname, email, password} = this.state;
    let restClient = new RestClient();
    console.log(firstname, lastname, email, password);
    let response = await restClient.POST('api/Account/register', {firstname, lastname, email, password})
    console.log(response);
  };
  return (
    <View style={styles.container}>
      <TextInput value={firstname} onChangeText={text => setFirstname(text)} placeholder="firstname"
        placeholderTextColor="#aaa" style={styles.input}/>
      <TextInput value={lastname} onChangeText={text => setLastname(text)} placeholder="lastname"
        placeholderTextColor="#aaa" style={styles.input}/>
      <TextInput value={email} keyboardType="email-address" onChangeText={text => setEmail(text)}
        placeholder="email" placeholderTextColor="#aaa" style={styles.input}/>
      <TextInput value={password} onChangeText={text => setPassword(text)} placeholder={'password'}
        secureTextEntry={true} placeholderTextColor="#aaa" style={styles.input}/>

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