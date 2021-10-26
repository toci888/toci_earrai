import React, {useEffect, useState} from 'react'
import { Alert, Text, TextInput, View, Button, TouchableOpacity, ActivityIndicator } from 'react-native'
import AppUser from '../shared/AppUser'
import RestClient from '../RestClient';
import { formStyles } from '../styles/formStyles';
import { Formik } from 'formik';
import * as yup from 'yup';

export default function Login({navigation}) {

  const [indicator, setIndicator] = useState(false);

  const checkIfLogged = async () => {
    let logged = await AppUser.checkIfAlreadyExists()
    console.log(logged)
    if(logged) {
      navigation.navigate('WorksheetRecord')
    } else {
      console.log("Failed to login")
    }
  }

  useEffect(() => {
    //checkIfLogged()
    navigation.navigate('WorksheetRecord')
  }, [])

  const login = async (values) => {
    setIndicator(true);
    let restClient = new RestClient();
    let response = await restClient.POST('api/Account/login', values)
    console.log(response);
    setIndicator(false);
    if(response)
    {
      AppUser.setUserData(response)
      navigation.navigate('Home');
    } else {
      Alert.alert("Login error", "Check e-mail and password.");
      console.log("error logowania");
    }
  };

  return (
    <Formik initialValues={{
      email: '',
      password: ''
    }}
    // <Formik initialValues={{
    //   email: 'admin@wp.pl',
    //   password: '12345678'
    // }}

    onSubmit={(values, {resetForm}) => {
      login(values);
      resetForm({values: {
        email: values.email,
        password: ''
      }});
    }}

    validationSchema={yup.object().shape({
      email: yup.string()
        .email()
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
