namespace examAPI.Migration;

CREATE TABLE users (
                       id UUID PRIMARY KEY,
                       userName VARCHAR(255) UNIQUE NOT NULL,
                       email VARCHAR(255) UNIQUE NOT NULL,
                       passwordHash VARCHAR(255) NOT NULL,
                       createdAt TIMESTAMP with time zone NOT NULL
);

CREATE TABLE categories (
                            id UUID PRIMARY KEY,
                            name VARCHAR(255) UNIQUE NOT NULL,
                            createdAt TIMESTAMP with time zone NOT NULL
);
CREATE TABLE tasks (
                       id UUID PRIMARY KEY,
                       title VARCHAR(255) NOT NULL,
                       description varchar,
                       isCompleted BOOLEAN NOT NULL DEFAULT FALSE,
                       dueDate TIMESTAMP,
                       userId UUID REFERENCES users(id) ON DELETE CASCADE,
                       categoryId UUID REFERENCES categories(id) ON DELETE CASCADE,
                       priority varchar ,
                       createdAt TIMESTAMP NOT NULL
);


CREATE TABLE comments (
                          id UUID PRIMARY KEY,
                          taskId UUID REFERENCES tasks(id) ON DELETE CASCADE,
                          userId UUID REFERENCES users(id) ON DELETE CASCADE,
                          content varchar NOT NULL,
                          createdAt TIMESTAMp with time zone NOT NULL
);

CREATE TABLE taskAttachments (
                                 Id UUID PRIMARY KEY,
                                 TaskId UUID REFERENCES Tasks(Id) ON DELETE CASCADE,
                                 FilePath VARCHAR(255) NOT NULL,
                                 CreatedAt TIMESTAMP NOT NULL 
);

CREATE TABLE taskHistory (
                             id UUID PRIMARY KEY ,
                             taskId UUID REFERENCES tasks(id) ON DELETE CASCADE,
                             changeDescription varchar NOT NULL,
                             changedAt TIMESTAMP with time zone NOT NULL
);
