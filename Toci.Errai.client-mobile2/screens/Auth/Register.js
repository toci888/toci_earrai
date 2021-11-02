import React, {useState} from 'react'
import { Alert, Text, TextInput, View, Button, TouchableOpacity, ActivityIndicator } from 'react-native';
import { Formik } from 'formik';
import * as yup from 'yup';
import RestClient from '../../shared/RestClient';
import { formStyles } from '../../styles/formStyles';

export default function Register({navigation}) {

  const [indicator, setIndicator] = useState(false);

  const register = async (values) => {
    setIndicator(true)
    let restClient = new RestClient();
    let response = await restClient.POST('api/Account/register', values)
    setIndicator(false);

    if(response > 0) {
      navigation.navigate('Login');
    } else if (response == 0) {
      Alert.alert("Register error", "This email is already used.");
      console.log("This email is already used")
    } else {
      Alert.alert("Failed to register", "Failed to register.");
      console.log("Failed to register")
    }
  };

  return (
    <Formik initialValues={{
        firstName: '',
        lastName: '',
        email: '',
        password: '' ,
        confirmPassword: ''
      }}
    // <Formik initialValues={{
        // firstName: 'b',
        // lastName: 'b',
        // email: 'b@wp.pl',
        // password: '1234' ,
        // confirmPassword: '1234'
      // }}

      onSubmit={(values, {resetForm}) => {
        register(values);
        resetForm({values: {
          firstName: values.firstName,
          lastName: values.lastName,
          email: values.email,
          password: '',
          confirmPassword: ''
        }});
      }}

      validationSchema={yup.object().shape({
        firstName: yup.string()
          .required('First name is required.'),
        lastName: yup.string()
          .required('Last name is required.'),
        email: yup.string()
          .email()
          .required('E-Mail is required.'),
        password: yup.string()
          .min(4)
          .max(10, 'Password should not excced 10 chars.')
          .required(),
        confirmPassword: yup.string()
          .oneOf([yup.ref('password'), null], 'Passwords must match')
          .required('Confirm Password is required')
      })}>

      {({ values, handleChange, errors, setFieldTouched, touched, isValid=false, handleSubmit }) => (
        <View style={formStyles.container}>
          <TextInput value={values.firstName} style={formStyles.input} onChangeText={handleChange('firstName')} onBlur={() => setFieldTouched('firstName')} placeholder="First name" />
          { touched.firstName && errors.firstName && <Text style={formStyles.required}>{errors.firstName}</Text> }
          <TextInput value={values.lastName} style={formStyles.input} onChangeText={handleChange('lastName')} onBlur={() => setFieldTouched('lastName')} placeholder="Last name" />
          { touched.lastName && errors.lastName && <Text style={formStyles.required}>{errors.lastName}</Text> }
          <TextInput value={values.email} style={formStyles.input} onChangeText={handleChange('email')} onBlur={() => setFieldTouched('email')} placeholder="E-mail"/>
          { touched.email && errors.email && <Text style={formStyles.required}>{errors.email}</Text> }
          <TextInput value={values.password} style={formStyles.input} onChangeText={handleChange('password')} placeholder="Password" onBlur={() => setFieldTouched('password')} secureTextEntry={true}/>
          { touched.password && errors.password && <Text style={formStyles.required}>{errors.password}</Text> }
          <TextInput value={values.confirmPassword} style={formStyles.input} onChangeText={handleChange('confirmPassword')} placeholder="Confirm password" onBlur={() => setFieldTouched('confirmPassword')} secureTextEntry={true}/>
          { touched.confirmPassword && errors.confirmPassword && <Text style={formStyles.required}>{errors.confirmPassword}</Text> }
          <Button color="#3740FE" title='Submit' disabled={!isValid} onPress={() => handleSubmit()} />
          <ActivityIndicator size="large" color="blue" animating={indicator}/>

          <Text style={formStyles.text}>Have already an account?</Text>
          <TouchableOpacity>
            <Text style={formStyles.touchableText} onPress={() => navigation.navigate('Login')}>Back to login</Text>
          </TouchableOpacity>
        </View>
      )}
    </Formik>
  );
}

console.disableYellowBox = true;