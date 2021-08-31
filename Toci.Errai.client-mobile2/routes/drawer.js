import { createDrawerNavigator } from '@react-navigation/drawer';
import { createAppContainer } from 'react-navigation';

import Login from './Login'
import Register from './Register'
import AboutStack from './aboutStack';
import HomeStack from './homeStack';


const RootDrawerNavigator = createDrawerNavigator({
    Home: {
        screen: HomeStack,
    },
    About: {
        screen: AboutStack,
    },
    Login: {
        screen: Login,
    },
    Register: {
        screen: Register,
    }
});


export default createAppContainer(RootDrawerNavigator);