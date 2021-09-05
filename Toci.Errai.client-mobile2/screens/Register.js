import React from 'react';
import { Alert, Text, TextInput, View, Button} from 'react-native';
import RestClient from '../RestClient';
import { formStyles } from '../styles/formStyles';
import { Formik } from 'formik';
import * as yup from 'yup';

export default function Register({navigation}) {
  const register = async (values) => {
    let restClient = new RestClient();
    let response = await restClient.POST('api/Account/register', values)
    console.log(response);
    if(response > 0) {
      navigation.navigate('Login');
    } else if (response > 0) {
      console.log("This email is already used")
    } else {
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
      onSubmit={values => register(values)}
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

      {({ values, handleChange, errors, setFieldTouched, touched, isValid, handleSubmit }) => (
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
          <Button color="#3740FE" title='Submit' disabled={!isValid} onPress={handleSubmit} />
        </View>
      )}
    </Formik>
  );
}

console.disableYellowBox = true;