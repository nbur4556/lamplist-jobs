import { PUBLIC_API_URL } from '$env/static/public';

import type { User } from '@src/store/AuthStore';

import type { StoreUpdater } from '../types';

const loginUser = async (userName: string, password: string, update: StoreUpdater<User>) => {
	const result = await fetch(`${PUBLIC_API_URL}/api/Auth/login`, {
		method: 'POST',
		headers: {
			'Content-Type': 'application/json'
		},
		body: JSON.stringify({ userName, password })
	});
	const response = await result.json();

	if (!response.succeeded || !response.authToken) {
		throw 'Login failed';
	}

	update(() => {
		return { userName, token: response.authToken };
	});
};

export default loginUser;
