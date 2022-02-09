import React, {useEffect, useState} from 'react'
import { Alert, Text, TextInput, View, Button, TouchableOpacity, ActivityIndicator } from 'react-native'
import AppUser from '../../shared/AppUser'
import { formStyles } from '../../styles/formStyles';
import { Formik } from 'formik';
import * as yup from 'yup';
import RestClient from '../../shared/RestClient';
import { environment } from '../../environment';
import ErrorEntity  from '../../ErrorHandling/ErrorEntity';
import AsyncStorage from '@react-native-community/async-storage'

export default function Login({navigation}) {

  const [indicator, setIndicator] = useState(false);

  const checkIfLogged = async () => {
    let logged = await AppUser.checkIfAlreadyExists()
    console.log(logged)
    if(logged) {
      navigation.navigate('WorksheetRecord')
    } else {
      console.log("Not logged already.")
    }
  }

  useEffect(() => {
    checkIfLogged()
  }, [])

  const login = async (values) => {
    setIndicator(true);
    
    let restClient = new RestClient();
    
    return await restClient.POST('api/Account/login', values).then(response => {
      console.log("LOGIN RESPONSE:")
      console.log(response);
      AppUser.logIn(response.id, response.token);
      AsyncStorage.setItem(AppUser.userName, response.token);
      setIndicator(false);

      if(response == undefined) {
        Alert.alert("Login error", "Check e-mail and password.");
        console.log("Your username or password may be incorrect");
        
      } else if(response) {
        AppUser.setUserData(response)
        navigation.navigate('WorksheetsList');
      }
      else {
        Alert.alert("Login error", "Check e-mail and password.");
        console.log("Log in ERROR NIe wiadomo jaki")
      }
    }).catch(e => {
      Alert.alert("Server error",  environment.apiUrl + "The server is probably down.");
      console.log("The server is probably down " + environment.apiUrl);
      setIndicator(false);
    });
  };

  return (
    <Formik initialValues={{
      email: 'user@wp.pl',
      password: '123456789'
    }}

    onSubmit={(values, {resetForm}) => {
      login(values);
      resetForm({values: {
        email: values.email,
        password: ''
      }});
    }}

    validationSchema={yup.object().shape({
      email: yup.string()
        //.email()
        .required('E-Mail is required.'),
      password: yup.string()
        .min(4)
        .required(),
    })}>

    {({ values, handleChange, errors, setFieldTouched, touched, isValid, handleSubmit }) => (
      <View style={formStyles.container}>
        <TextInput value={values.email} style={formStyles.input} onChangeText={handleChange('email')} onBlur={() => setFieldTouched('email')} placeholder="E-mail"/>
        { touched.email && errors.email && <Text style={formStyles.required}>{errors.email}</Text> }
        <TextInput value={values.password} style={formStyles.input} onChangeText={handleChange('password')} placeholder="Password" onBlur={() => setFieldTouched('password')} secureTextEntry={true}/>
        { touched.password && errors.password && <Text style={formStyles.required}>{errors.password}</Text> }
        <Button color="#3740FE" title='Submit' disabled={!isValid} onPress={() => {handleSubmit()}} />
        <ActivityIndicator size="large" color="blue" animating={indicator}/>

        <Text style={formStyles.text}>Don't have an account?</Text>
        <TouchableOpacity>
          <Text style={formStyles.touchableText} onPress={() => navigation.navigate('Register')}>Sign up</Text>
        </TouchableOpacity>
      </View>
      )
    }
    </Formik>
    );
  }
