import { PUBLIC_API_URL } from '$env/static/public';

import { AuthStore } from '@src/store/AuthStore';
import { JobListStore } from '@src/store/JobListStore';

const registerUser = async (userName: string, password: string) => {
  AuthStore.logout();
	JobListStore.emptyStore();

	const result = await fetch(`${PUBLIC_API_URL}/api/Auth/register`, {
		method: 'POST',
		headers: {
			'Content-Type': 'application/json'
		},
		body: JSON.stringify({ userName, password })
	});
	const response = await result.json();

	if (!response.succeeded) {
		throw response.errors;
	}
};

export default registerUser;
