import { StyleSheet } from 'react-native';

export const formStyles = StyleSheet.create({
  container: {
    flex: 1,
    alignItems: 'center',
    justifyContent: 'center',
    backgroundColor: '#ddd',
  },
  input: {
    width: 200,
    backgroundColor: '#ddd',
    fontSize: 20,
    height: 44,
    padding: 10,
    borderWidth: 1,
    borderColor: '#777',
    marginVertical: 10,
  },
  required: {
    fontSize: 18, 
    color: '#FF0D10'
  },
  text: {
    marginTop: '2%', 
    fontSize: 15
  },
  touchableText: {
    fontSize: 20, 
    fontWeight: 'bold'
  }
})
  