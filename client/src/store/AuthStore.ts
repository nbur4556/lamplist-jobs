import { writable } from 'svelte/store';

import { loginUser, logoutUser, registerUser } from '@src/features/auth';

export interface User {
	id?: string;
	userName?: string;
	token?: string;
}

const createAuthStore = () => {
	const storageKey = 'auth';
	const hasLocalStorage = typeof localStorage === 'object';

	// Get auth store from local storage if existing
	const persistentUser: User = hasLocalStorage
		? localStorage.getItem(storageKey)
			? JSON.parse(localStorage.getItem(storageKey) || '')
			: {}
		: {};

	const store = writable<User>(persistentUser);

	// Updates local storage when there is a change to the auth store
	store.subscribe((user) => {
		if (hasLocalStorage) {
			localStorage.setItem(storageKey, JSON.stringify(user));
		}
	});

	return {
		subscribe: store.subscribe,
		register: (userName: string, password: string) => registerUser(userName, password),
		login: (userName: string, password: string) => loginUser(userName, password, store.update),
		logout: () => logoutUser(store.set)
	};
};

export const AuthStore = createAuthStore();
