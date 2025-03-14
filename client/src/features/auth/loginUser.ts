import { PUBLIC_API_URL } from '$env/static/public';

import type { User } from '@src/store/AuthStore';
import { JobListStore } from '@src/store/JobListStore';

import type { StoreUpdater } from '../types';

const loginUser = async (userName: string, password: string, update: StoreUpdater<User>) => {
	JobListStore.emptyStore();

	const result = await fetch(`${PUBLIC_API_URL}/api/Auth/login`, {
		method: 'POST',
		headers: {
			'Content-Type': 'application/json'
		},
		body: JSON.stringify({ userName, password })
	});

	// FIX: fix-api-end-of-json-error: getting no response from this. Why?
	const response = await result.json();

	// FIX: fix-api-end-of-json-error: this error will not be thrown if the result or response promises do not respond. Will get a generic error.
	if (!response.succeeded || !response.authToken) {
		throw 'Login failed';
	}

	update(() => {
		return { userName, token: response.authToken };
	});
};

export default loginUser;
