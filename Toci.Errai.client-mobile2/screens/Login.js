import React, {useEffect } from 'react'
import { Alert, Text, TextInput, View, Button } from 'react-native'
import AppUser from '../shared/AppUser'
import RestClient from '../RestClient';
import { formStyles } from '../styles/formStyles';
import { Formik } from 'formik';
import * as yup from 'yup';

export default function Login({navigation}) {
  const checkIfLogged = async () => {
    let logged = await AppUser.checkIfAlreadyExists()
    console.log(logged)
    if(logged) {
      navigation.navigate('Home')
    } else {
      console.log("Failed to login")
    }
  }

  useEffect(() => {
    checkIfLogged()
  }, [])

  const login = async (values) => {
    let restClient = new RestClient();
    let response = await restClient.POST('api/Account/login', values)
    console.log(response);

    if(response)
    {
      AppUser.setUserData(response)
      navigation.navigate('Home');
    } else {
      console.log(123);
    }
  };

  return (
    <Formik initialValues={{
      email: '',
      password: ''
    }}
    validationSchema={yup.object().shape({
        email: yup.string()
            .email('Email is invalid')
            .required('Email is required'),
        password: yup.string()
            .min(6, 'Password must be at least 6 characters')
            .required('Password is required'),
    })}
    onSubmit={values => {login(values)}}
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
            <Button color="#3740FE" title='Submit' disabled={!isValid} onPress={handleSubmit} />
          </View>
      )}
    </Formik>
    );
  }
