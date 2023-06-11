import { writable } from 'svelte/store';

import { loginUser, logoutUser, registerUser } from '@src/features/auth';

export interface User {
	id?: string;
	userName?: string;
	token?: string;
}

//TODO: Persistent user data between sessions if token has not expired
const createAuthStore = () => {
	const { subscribe, update, set } = writable<User>({});

	return {
		subscribe,
		register: (userName: string, password: string) => registerUser(userName, password),
		login: (userName: string, password: string) => loginUser(userName, password, update),
    logout: () => logoutUser(set),
	};
};

export const AuthStore = createAuthStore();
