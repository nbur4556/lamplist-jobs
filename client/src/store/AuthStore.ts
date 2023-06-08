import { writable } from 'svelte/store';

import { loginUser, registerUser } from '@src/features/auth';

export interface User {
	id?: string;
	userName?: string;
}

const createAuthStore = () => {
	const { subscribe, update } = writable<User>({});

	return {
		subscribe,
		register: (userName: string, password: string) => registerUser(userName, password, update),
		login: (userName: string, password: string) => loginUser(userName, password, update)
	};
};

export const AuthStore = createAuthStore();
