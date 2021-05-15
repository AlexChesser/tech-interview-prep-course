# how I cleared L6 System Design - Part 1

Reference <https://www.teamblind.com/post/Giving-back---how-I-cleared-L6-System-Design---Part-1-4yufM3RY>

## 1. Intro

I spent 6 months preparing overall. In the evenings before going to sleep I'd spend some time on Blind to get my hopes up and see a joke or two. There are some assholes here and there on Blind, but the majority are good people. I love you all. So now that I'm 'across the river' I decided to give back and provide some hints specifically on the System Design rounds.

I interviewed at Amazon, Twitter, Google, Facebook, Databricks and Elastic for L6 (or L6 equivalent). I cleared them all with exception of Twitter. I cleared Google and Facebook first then had 'emergency' interviews with the rest of the companies to ensure I was well-placed for the inevitable lowballing dance. One Friday I had half-onsite with Elastic in the morning and half-onsite with Twitter in the evening. I completely messed up the System Design for Twitter and that killed my prospects. I regret that though, as I liked Twitter.

I am not a genius, I'm just a hardworking tenacious guy. Don't let anyone tell you you're not smart enough for L6. It's all about mustering the motivation, channeling the work and executing it well.

I made the decision to try 6 months ago, and I prepared throughout that time while being at work. So my preparation hints will suppose long-term prep. If you're expecting a two-week crash course this is not for you.

I'm conscious some of this intro will read like a flex - it is genuinely not - but I'm sure the context will be helpful to many so I decided to make that tradeoff ;)

## 2. Content

Where do you start? Get the Designing Data Intensive Applications book. This will fill your theoretical gaps. Read it slowly. *Do not make fake progress*. If you don't understand something stop, use the references, research the subjects, get out of the book and back. There is *nothing* useless for you in that book. Nothing too much. It's all for you cover to cover. Properly grasping that book is half of the whole work. Part 1 is super useful to teach you how to pick data stores. Part 2 will dispel your fears of sharding and choosing a replication mechanism. Part 3 will give you a full idea on how to piece a big system together from smaller systems. The separation of System of record and derived data is key to understand there.

When you think you're done with DDIA, if I wake you up in the middle of the night you should be able to explain to me how LSMT-based databases use Red Black Trees to keep a sorted log in memory and why they do that, and then get back to sleep. I'm serious.

Next up, pay for Grokking the system design interview.

I know that Grokking can be too shallow. Nevertheless, I want you to be able to recite the solutions in Grokking down to the smallest details. Details are more important than the big picture for L6. Do you think your done with typeahead suggestions? Did you mention exponential moving average on how you weigh results? No? Failed.

You can leave the pastebin and bitly and that easy crap uncovered, but I'll need you to recite the other grokking solutions to the smallest details. Take extra care on the geospatial problems. If I show up at your lunch and ask you about quad trees I want you to be able to estimate the index size on the spot. You can't? Not ready yet.

Next up: videos. InfoQ and @scale videos about real life systems. Look up Nathan Bronson and suck up all his videos on Tao, Caches etc. Look up Nishtala and the memcache video. Look up Kulkarni and the Facebook live video. Look up Susheel Aroskar and his Zuul push video <- ultra useful.

Again, never make fake progress. Take this last one: Aroskar's Zuul push. He mentions Apache Netty. Read up on it, understand it. Go deeper, understand epoll and its red black trees. Go deeper and understand the TIMED-WAIT trick in TCP protocol which saves some web sockets connections. Another thing: he mentions some load balancers can't handle websockets. Why? Go figure it out. I did and I impressed my Facebook interviewer as I went deep until I was stopped as the interviewer lost it. L6 means depth, depth, depth. If you draw me a block that says 'Server' and leave it at that I'll slap you back to L3.

Now I went the extra mile. But I wasn't targeting barely making it - I was targeting mind-blowing performance. If you want the hardcore stuff, let me know and I'll give you content for that as well. If you're up for anecdotes, a Google interviewer challenged me on Paxos when I mentioned Spanner to him. I drew the multi-Paxos detailed flow for him with estimated latencies supposing a 5-replica configuration with the pivot replica on north-east US. He smiled and said 'ok' (Strong hire).

Next up, the Google SRE book. Did you say you're not interviewing for SRE? Don't care. You don't need it all. You do need the chapter on Non-Abstract Large System Design. You need to be able to recite that in your sleep. Especially the estimations part. You don't have NALSD interview? *rolls eyes* Don't care, learn the NALSD chapter or fail.

## 3. Speaking of Estimations

Ultra important. If you can't handle these, you're most likely ducked. How do you prepare for them? Practice power of 10 calculations. See how the NALSD chapter does it. Practice with fake numbers. Drag the units with you and reduce them when dividing/multiplying.

When calculating storage, consider cold storage. Also consider e.g. cassandra needs ±30% free space to do compacting (see, I told you to properly learn LSTMs in Part 1 of DDIA), also keep in mind that only ±85% of the disk space is usable (OS files, formatting tables etc.), also keep in mind that 3-5% of disks die in a year so account for that, also keep in mind that you need to multiply by replication factor, also keep in mind that cassandra says no more than 2TB disks otherwise it gets slow.

Have a strong grasp on the -bound concepts. Is something storage-bound (Log dumps)? Is something cpu-bound (live stream encoding)? Is something RAM bound (in-memory timeline serving)? Once you grasp those you design tiers with separate scaling techniques. That's why you need numbers, not to show off your math but to figure the -bound part and then decide how to scale a specific tier.

I'll wrap up this part here. In the second part I'll get into some sample walk-throughs of some popular questions. Then I'll give a you a detailed plan on how to spend the 45 minutes. I did 9 System Design interviews in the space of 5 weeks so it's fresh in my head.

Now you might think this is a lot of work. It is. It depends on how much you want the job. Want it badly? Throw in the effort then, that's all it takes. Was it worth the effort for me? Yes.

Old TC: 175K USD, New TC: 593k USD

## Part 2

0. Preface

Let me touch on some points from Part 1 flood of comments:

Is Nathan Bronson a porn star? I'm not sure if Nathan Bronson of Facebook has a side gig but I meant the other non-porn star Bronson.

YOE? 10. Don't let YOE hold you back though. I've always been somehow the youngest of my peers at something. Age? Early 30s.

Did I have coding rounds? Of course. I will write about that but it will have to wait. Plenty of coding hints on Blind on how to leetcode but I think the shortage is on SDI content so I want to plug that first.

How did I manage the time? I had a method which I'll share eventually.

---- end preface ----

- Back of the envelope calculations (BOTEC)

You expected something else? Sit down... I thought hard and I think this is something many people secretly fear and feel weak on. So since my goal in this effort is to genuinely help people, I think this is where my contribution is most valuable.

You might think why do we even need BOTEC? Short version is to size tiers. What? Size? Tiers? Sizing as a verb here means to estimate how many machines/disks/etc. you will need. Tiers in this context means the typical tier in any system development. For example, a logging/counting system can have three tiers: 1. the collection tier, 2. the aggregation tier and 3. the storage tier.

Another way you can use BOTEC is to figure out if something can fit in one machine or not, mostly memory wise. Most of the time it is self-evident, but 10 seconds of BOTEC should confirm it.

Example: How do you serve the timelines of 1 Million people efficiently? Well how many posts do you expect to have readily available per person? Let's say 10. Ok. If we store the IDs only (say 64 bit) we can use a redis native list to store list of posts:

8 bytes/post * 10 post/timeline=80 bytes/timeline (post goes away)
1 Million timelines * 80 bytes/timeline = 10^6*10^1*8=8*10^(6+1) bytes (timeline goes away)

so 80 million bytes means 80 MB - easily goes into one machine's RAM.

This was an easy example however note two things: always drag the units with you: bytes/post, post/timeline and reduce when possible. It's extremely helpful to not get lost. Second, always use powers of 10 to not miss a zero here and a zero there.

Here's the real life version of that.
-64 bit ID per post - 8 bytes/post
-800 posts/timeline
-500 million timelines
-replication factor of 3

800 posts / timeline * 8 bytes/post = (post goes away) 8*10^2 * 8 bytes/timeline= 64 * 10^2 bytes/timeline

500 million timelines* 64 * 10^2 bytes/timeline = (timeline goes away) 5 * 10^2 * 10^6 * 64 * 10 ^2 bytes= 5*64 * 10 ^(2+6+2) bytes= 300 * 10^10 = 3 *10^12 bytes = 3 TBs

3TBs * 3 (unitless replication factor) = ±10 TB. Considering 64 GB ram/machine out of which 50 can be considered usable you have 10 TB/(50GB/machine) = 10* 10^12 Bytes /(5*10^9)Bytes/machine= 2 *10^3 =2000 Machines (Bytes goes away, 1 over 1 over machine becomes machine).

The temptation here is to stop being pedantic with units but I suggest you don't. These can get messy so stick to it.

This tier can be considered to be memory-bound.

Look up Raffi Krikorian's Timelines at Scale on infoQ to see him talk about this at more length.

Usually you have different tiers with different scaling mechanisms. Do your calculations early to get a feeling of what is going to be the bounding factor, then plan ahead to scale that accordingly.

Here's an example of a QPS-bound tier. You're told you'll have to log 100 billion events per day. Ok. That sounds like a lot. Let's turn that into per second. Is that a calculator you took out? *takes it and throws out the window*

100 * 10^9 events/day [divided by] 86400 seconds/day
round to a convenient number
100 * 10^9 events/day [divided by] 80000 seconds/day=
10^11/(8*10^4) events/second (1 over day goes away)=1/8 *(10^7)Events/sec= 10/8 Million QPS=~1.2 Million QPS

This looks to be a QPS bound tier. To size it, divide it by some (numerically convenient) number that can be handled by one machine and you get the number of machines.

Same goes for storage sizing. Keep in mind the replication factor in storage and the amount of time you will be storing for. Look up datastax capacity planning for cassandra numbers, they're super useful.

And last but not least here are some numbers I used to reference quite often. They're taken from various sources and I used them without causing dropped jaws, so it should be safe.

- Compress 1KB with Zippy - 0.003 ms
- Send 1KB over 1Gbps 0.01 ms
- Read 4MB of sequential memory is 1 ms
- Read 4MB of sequential SSD is 20 ms
- Read 4MB of sequential HDD is 80 ms
- One single disk seek is 10 ms
- Inter-datacenter roundtrip 150ms
- Inter-datacenter bandwidth ±100 Gbps
- Video is roughly 10 MB/minute
- A server can have 100-150GB of usable RAM
- Cassandra is best used with 1-2TB storage / node
- A 1Gbps link can handle max of 125 MB /s
- Cassandra cluster can handle 10-15000 reqs/s/node and grows linearly with number of nodes
- 720p video - 1.5Mbps
- 340 video - 150Kbps

End of part 2

## Part 3

how I cleared L6 System Design - Part 3
Red Hat  flung
  59 Comments
This is part 3 of a series. Here is the link to part 1: https://www.teamblind.com/post/Giving-back---how-I-cleared-L6-System-Design---Part-1-4yufM3RY

- Preface: LINKS

Many people seem to have had trouble digging up the material I have referenced in my previous posts. Here is the list:

DDIA - https://dataintensive.net/buy.html
Grokking - https://www.educative.io/courses/grokking-the-system-design-interview
Nathan Bronson's Tao: https://www.usenix.org/conference/atc13/technical-sessions/presentation/bronson
Nishtala's memcache: https://www.usenix.org/conference/nsdi13/technical-sessions/presentation/nishtala
Kulkarni's Facebook live: https://www.youtube.com/watch?v=IO4teCbHvZw
Aroskar's Zuul push: https://www.youtube.com/watch?v=6w6E_B55p0E
NALSD on Google SRE book: https://sre.google/workbook/non-abstract-design/
Krikorian's timelines at scale: https://www.infoq.com/presentations/Twitter-Timeline-Scalability/
Cassandra's capacity planning guidelines by datastax: https://docs.datastax.com/en/dse-planning/doc/planning/capacityPlanning.html
Youtube guy: https://www.youtube.com/channel/UC9vLsnF6QPYuH51njmIooCQ

===== Extra mile stuff ====

Check Bronson's TAO pdf paper in same link as video
Check Nishtala's pdf paper in same link as video
Lamport's ordering paper: https://lamport.azurewebsites.net/pubs/time-clocks.pdf
Paxos (simpler version, not the greek parliament metaphor version): https://www.microsoft.com/en-us/research/publication/paxos-made-simple/
Raft: http://thesecretlivesofdata.com/raft/ and also http://kanaka.github.io/raft.js/
Dynamo: https://www.allthingsdistributed.com/2007/10/amazons_dynamo.html

-- end of Preface --

This part will focus on logistics and time management on the day of the interview. This stuff is less 'scientific' in nature. It's the way I did it and it served me quite well.

Let's suppose your interview starts at 11.00 and lasts 45 mins. Do NOT go in cold. Keep the hour before open. At 10.00 start a mock. Pick a question you're comfortable with. Work on it alone until 10.30. Everyone that has done a day of sport knows this - never go in with cold muscles. Same goes for the brain.

At 10.30 start double checking your setup. Do not underestimate this part. It is *your* responsibility to have a smooth setup from your side. I had a phone ready as a backup internet connection if my cable connection crapped on me. Stick to cable if possible and not Wifi. Check the camera and the angle and make sure it's pretty neutral with the background etc.

Don't wear fancy stuff. You're not getting married. Anything simple works, as long as it's not distracting. By 10.45 you should be done with this stuff. Between 10.45 and 11.00 do all the natural stuff, eat, drink (don't plan to do any drinking during interview - no distractions), pee, poo.

At 10:59 be ready near your desk. Take out your phone and start a timer that you'll be able to see throughout. Start it at 46 minutes and keep it running and visible. Don't get over-eager and join the call at 10:55. No one will give you points for being early. Join the call as soon as it clocks 11.00.

Now before I go into this, I have a hint. At this stage your mind gets some extra excitement and the body responds too. Do not let your mind race. Keep your mind in the exact middle. Don't pull it to tight and don't let it too loose. The body can react with some tension, it's ok. But keep the mind in the exact center. It will naturally start working faster when you get into the exercise but keep calm as you join.

The interviewer usually joins on time. Say 'Hi' and stay neutral. Don't get all smiley and over-friendly and 'OMG I'm talking to an L7' and all that crap. Keep it neutral. No one cares. As the discussion gets going aim for as short intro as possible. These are precious minutes. The sooner you start the real deal the better. It shouldn't last more than 5 minutes.

Once you hear the problem start asking clarifying questions. It should take 5 (10 max) minutes to clarify. As you take notes of the answers start thinking of calculations in the background. Once you have clarified the problem, start doing some back of the envelope calculations. Usually that can involve QPS, Storage, Ram etc. (see part 2). I tend to do back of the envelope calculations in two places: a) in the beginning to inform my high-level design. b) in the detail phase to size tiers. These initial calculations shouldn't take more than 5 minutes.

So until now you have 5 intro+5 clarification+5 calculations=15 minutes mark. This is when you do the high-level design. That should be around 10 minutes. By the 25 minute-mark you should be done with the High-level stuff.

As you are drawing the high-level design stuff, start a background thread in your head and start thinking about the -bound (see part 2) of different components. It can be done in parallel, don't freak out. We do that all the time, especially when you talk to that boring friend (shakes head pretending to listen).

After you're done with high level, you have a key checkpoint. Ideally you'll have the intuition to nail the component that need details the most. You can't go into details on all components. You have time only for 2-3. What you do here is you propose your plan to the interviewer. Say 'Now that we have an initial High-level draft in place I propose to get into the details of these components here as I find them to be most interesting to detail'. Then look at the interviewer for any clue. If you nail this is it's extra point. However they might want to hear about something else and might steer you elsewhere. Not the end of the world, but it's best if you nail it yourself.

Now the next 15 minutes need to be spent going deep in some component until you feel you covered that, then pull up, get into the next component to detail and go deep there too. As you go deep you might have to do some sizing calculations. They take 3-5 minutes at least so be selective, it's hard to do calculations for everything. Decide which component to detail with calculations, get validation from interviewer and get to it. In the end, pull up, look at the whole thing and make some potential overarching comments. Maybe observability, evolvability, infrastructure needs etc.

As I mentioned earlier, keep it neutral. No jokes, funny drawings and other crap like that.

So to recap:
5 - intro (keep it short, you'll need every minute you can get)
5 - clarifications on the question
5 - initial back of envelope calcs
10-high-level design
15-deep stuff+sizing calcs+closing overarching comments
5-questions from you (as long as you don't ask completely dumb questions, you should be fine)
---
45 minutes

Some interviewers will give you some extra minute but don't count on that. Prepare to be sharp on time.

That's it for Part 3. There will be a Part 4.
----

One last comment, I've received around 200+ private messages. I will eventually reply, please be patient. You can definitely PM me, just be conscious it might take a while to receive a reply. I have been on the other side of it so I know it can be frustrating when you receive no reply on a PM. But have some patience, the response to these posts has been overwhelming and I decided to spend most of my available time to write more content first, and respond to messages next. I think I'm helping more people this way.
