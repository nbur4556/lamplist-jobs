const removeEmptyKeys = <T>(obj: T) => {
	let cleanObj: Partial<T> = {};

	for (const k in obj) {
		const key = k as keyof T;

		if (obj[key] === undefined || obj[key] === null) {
			continue;
		}

		cleanObj = { ...cleanObj, [key]: obj[key] };
	}

	return cleanObj;
};

export default removeEmptyKeys;
