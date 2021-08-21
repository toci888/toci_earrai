
import { createStackNavigator } from 'react-navigation-stack'
import About from '../screens/About'


const screens = {
    About: {
        screen: About,
        navigationOptions: {
            title : "About",
            headerStyle: { backgroundColor: '#333' }
        }
    }
}

const AboutStack = createStackNavigator(screens, {
    defaultNavigationOptions: {
        headerTintColor: '#444',
        headerStyle: { backgroundColor: '#eee', height: 70 }
    }
});



export default AboutStack;
