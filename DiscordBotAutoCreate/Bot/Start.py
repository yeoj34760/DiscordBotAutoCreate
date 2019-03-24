import discord
import json
import asyncio 
import os

client = discord.Client()
with open(os.path.dirname(os.path.realpath(__file__)) + '\BotSetting.json', 'rt', encoding='UTF8') as data_file:    
        data = json.loads(data_file.read())
@client.event
async def on_ready():
    print('Logged on as', client.user)

@client.event
async def on_message(message):
    for key in data['command'].keys():
        if data['command'][key]['PLUS'] == False:
            if message.content == key:
                await client.send_message(message.channel, content = data['command'][key]['answer'])
        else:
            if message.content == key or message.content == key + '는' or message.content == key + '는?' or message.content == key + '은' or message.content == key + '은?':
                await client.send_message(message.channel, content = data['command'][key]['answer'])
client.run(data['token'])